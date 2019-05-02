using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownToHtml
{
    public class Converter
    {
        public string Text { get; set; }    //input in formato markdown
        public string Html { get; set; }    //file convertito in HTML
        private int skip;                  //permette di far saltare diversi cicli al foreach del main thread
        private bool boldActivated;
        private bool italicsActivated;
        private bool blockquoteActivated;
        private bool beginningOfLine;
        private bool beginningStrike;       //controllo per il tag <strike>
        private int index;                  //posizione dell'item selezionato nella stringa "Text"
        private int headerKey;
        private int i;
        private bool orderedListActivated;      //per il controllo dell'attivazione di una lista ordinata
        private bool unorderedListActivated;    //per il controllo dell'attivazione di una lista ordinata
        private bool codeActivated;             //per il controllo dell'attivazione di un blocco di codice

        public Converter()           //costruttore
        {
            Text = "";
            Html = "";
            skip = 0;
            boldActivated = false;
            italicsActivated = false;
            blockquoteActivated = false;
            beginningOfLine = true;
            beginningStrike = true;
            index = -1;
            headerKey = 0;
            i = 0;
            orderedListActivated = false;
            unorderedListActivated = false;
            codeActivated = false;
        }

        /// <summary>
        /// Converts the entire text from markdown to html and saves it in the Html property
        /// </summary>
        public void Convert(string text)                 //Metodo principale
        {
            Text = text;
            Html = "";
            foreach (char item in Text)
            {
                index++;
                if (skip != 0)
                {
                    skip--;
                    continue;
                }
                if (item == '#' && beginningOfLine && !codeActivated)
                {
                    i++;
                    continue;
                }
                if ((Int32.TryParse(item.ToString(), out int valore) || orderedListActivated) && !codeActivated)            //liste ordinate
                {
                    if (ConvertOrderedList(orderedListActivated, item))
                        continue;
                }
                if ((item == '+' || item == '-' || item == '*' || unorderedListActivated) && !boldActivated && !italicsActivated && !codeActivated)                //liste non ordinate
                {
                    if (ConvertUnorderedLists(unorderedListActivated, item))
                        continue;
                }
                if (item == '~' && !codeActivated)
                {
                    if (ConvertStrikeEmphasis()) { skip = 1; }
                    else { Html += item; }
                    continue;
                }
                if ((item == '*' || item == '_') && !codeActivated)
                {
                    int emphasisType = CheckEmphasis(item);
                    if (emphasisType == 1)
                    {
                        italicsActivated = ConvertItalicsAndBold(true, italicsActivated);               //true perchè è corsivo
                        continue;
                    }
                    else if (emphasisType == 0)
                    {
                        boldActivated = ConvertItalicsAndBold(false, boldActivated);                    //false perchè è grassetto
                        continue;
                    }
                    //se emphasisType == 2, continua il ciclo, in quanto non si tratta nè di italics nè di bold
                }
                if (item == '>' && beginningOfLine && !codeActivated)
                {
                    if (ConvertBlockquote())
                    { continue; }
                }
                if (item == '[' && !codeActivated)
                {
                    if (ConvertLink())
                        continue;
                }
                if (item == '!' && !codeActivated)
                {
                    if (ConvertImage())
                        continue;
                }
                if ((item == (char)39 && beginningOfLine) || codeActivated)
                {
                    if (ConvertCode())
                        continue;
                }
                if (item == '\n')
                {
                    if (headerKey != 0)
                    {
                        Html += "</h" + headerKey + ">";
                        Html += Environment.NewLine;
                        i = 0;
                        headerKey = 0;
                        beginningOfLine = true;
                    }
                    else if (orderedListActivated)
                    {
                        Html += "</li>" + Environment.NewLine + "</ol>" + Environment.NewLine;
                        orderedListActivated = false;
                        beginningOfLine = true;
                    }
                    else if (unorderedListActivated)
                    {
                        Html += "</li>" + Environment.NewLine + "</ul>" + Environment.NewLine;
                        unorderedListActivated = false;
                        beginningOfLine = true;
                    }
                    else if (blockquoteActivated)
                    {
                        Html += "</blockquote>" + Environment.NewLine;
                        blockquoteActivated = false;
                        beginningOfLine = true;
                    }
                    else if (!beginningOfLine && !codeActivated)
                    {
                        Html += "</p>" + Environment.NewLine;
                        beginningOfLine = true;
                    }
                    else if (beginningOfLine && !codeActivated) { Html += "<hr>" + Environment.NewLine; beginningOfLine = true; }
                    else { Html += Environment.NewLine; }
                }
                else
                {
                    if (i == 0 && beginningOfLine && !orderedListActivated && !unorderedListActivated && !italicsActivated && !boldActivated && !blockquoteActivated && !codeActivated)
                    {
                        Html += "<p>" + item;
                        beginningOfLine = false;
                    }
                    else if (i != 0)
                    {
                        headerKey = i;
                        Html += "<h" + headerKey + ">";
                        i = 0; beginningOfLine = false;
                    }
                    else
                    { Html += item; }
                }
            }
        }

        #region Inline styles
        /// <summary>
        /// Converts strike inline style to html tags
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertStrikeEmphasis()
        {                                                                         
            try
            {
                if (Text[index + 1] == '~')
                {
                    if (beginningStrike)
                    {
                        Html += "<strike>";
                        beginningStrike = false;
                    }
                    else
                    {
                        Html += "</strike>";
                        beginningStrike = true;
                    }
                    return true;
                }
                else
                { return false; }
            }
            catch { return false; }
        }
        /// <summary>
        /// Converts italics and bold inline styles to html tags
        /// </summary>
        /// <param name="type">true if it's needed to convert italics inline style, otherwise false</param>
        /// <param name="activated">true if the html tags have already been written before and therefore are not needed</param>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertItalicsAndBold(bool type, bool activated)
        {
            if (type && !activated)
            {
                Html += "<i>";
                activated = true;
            }
            else if (type && activated)
            {
                Html += "</i>";
                activated = false;
            }
            else if (!type && !activated)
            {
                Html += "<b>";
                activated = true;
                skip = 1;
            }
            else
            {
                Html += "</b>";
                activated = false;
                skip = 1;
            }
            return activated;
        }
        /// <summary>
        /// This method is able to recognize the type of inline style
        /// </summary>
        /// <param name="char_">The current char</param>
        /// <returns>returns 0 for bold, 1 for italics and 2 for unhandled exceptions</returns>
        private int CheckEmphasis(char char_)
        {
            try
            {
                if (char_ == '*' && Text[index + 1] == '*')
                { return 0; }
                else if (char_ == '_' && Text[index + 1] == '_')
                { return 0; }
                else
                { return 1; }
            }
            catch { return 2; }
        }
        #endregion

        #region Ordered Lists
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertOrderedList(bool activated, char item)
        {
            try                                         //evitare errori di limite di lunghezza della stringa
            {
                if (Text[index + 1] == '.')             //vi entra solo solo quando !activated, quindi solo 1 volta all'inizio
                {
                    skip = 2;
                    orderedListActivated = true;
                    beginningOfLine = false;
                    Html += "<ol>" + Environment.NewLine + "    <li>";
                    return true;
                }
                else if (Int32.TryParse(Text[index + 3].ToString(), out _) && Text[index + 4] == '.' && item != '\n')           //si verifica quando c'è almeno un secondo elemento nella lista
                {
                    if (System.Convert.ToChar(Text[index + 1]) != '\n')
                    {
                        Html += item + Text[index + 1].ToString() + "</li>" + Environment.NewLine + "    <li>";
                    }
                    else
                    {
                        Html += item + "</li>" + Environment.NewLine + "    <li>";
                    }
                    skip = 5;
                    return true;
                }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Unordered Lists
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertUnorderedLists(bool activated, char item)
        {
            try                                         //evitare errori di limite di lunghezza della stringa
            {
                if (Text[index + 1] == ' ' && (Text[index] == '+' || Text[index] == '-' || Text[index] == '*'))             //vi entra solo solo quando !activated, quindi solo 1 volta all'inizio
                {
                    skip = 1;
                    unorderedListActivated = true;
                    beginningOfLine = false;
                    Html += "<ul>" + Environment.NewLine + "    <li>";
                    return true;
                }
                else if ((Text[index + 1] == '+' || Text[index + 1] == '-' || Text[index + 1] == '*') && Text[index + 2] == ' ')      //si verifica solo quando item == \n
                {
                    Html += "</li>" + Environment.NewLine + "    <li>";
                    skip = 2;
                    return true;
                }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Blockquote
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertBlockquote()
        {
            try
            {
                if (Text[index] == '>' && Text[index + 1] == ' ')
                {
                    Html += "<blockquote>";
                    blockquoteActivated = true;
                    beginningOfLine = false;
                    skip = 1;
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Link
        /// <summary>
        /// Gets the URL of the link
        /// </summary>
        /// <returns>returns the URL of the link</returns>
        private string GetLinkAddress()
        {
            try
            {
                string address = Text.Substring(index);
                string[] trimmedString = address.Split(new char[] { '(', ')' });
                return trimmedString[1];
            }
            catch { return ""; }
        }
        /// <summary>
        /// Gets the text of the link
        /// </summary>
        /// <returns>returns the text of the link</returns>
        private string GetLinkText()
        {
            try
            {
                string address = Text.Substring(index);
                string[] trimmedString = address.Split(new char[] { '[', ']' });
                return trimmedString[1];
            }
            catch { return ""; }
        }
        /// <summary>
        /// Gets the lenght of the markdown code of the link, needed to skip useless characters
        /// </summary>
        /// <returns>returns the lenght of the markdown code of the link</returns>
        private int GetLinkLenght()
        {
            try
            {
                string address = Text.Substring(index);
                return address.IndexOf(')');
            }
            catch { return 0; }
        }
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertLink()
        {
            try
            {
                if (Text[index + 1] != ' ')
                {
                    string text = GetLinkText().Trim();
                    string link = GetLinkAddress().Trim();
                    if (link == "" || text == "")
                        return false;
                    skip = GetLinkLenght();
                    if (beginningOfLine)
                        Html += @"<p><a href=""" + link + @""">" + text + "</a>";
                    else
                        Html += @"<a href=""" + link + @""">" + text + "</a>";
                    beginningOfLine = false;
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }
        #endregion

        #region Images
        /// <summary>
        /// Gets the link or path to the image
        /// </summary>
        /// <returns>returns the link or the path of the image</returns>
        private string GetImageAddress()
        {
            try
            {
                string address = Text.Substring(index);
                string[] trimmedString = address.Split(new char[] { '(', ')', '"' });
                return trimmedString[1];
            }
            catch { return ""; }
        }
        /// <summary>
        /// Gets the alt-text of the image
        /// </summary>
        /// <returns>returns the alt-text of the image</returns>
        private string GetImageText()
        {
            try
            {
                string address = Text.Substring(index);
                string[] trimmedString = address.Split(new char[] { '"' });
                return trimmedString[1];
            }
            catch { return ""; }
        }
        /// <summary>
        /// Gets the lenght of the markdown code of the image, needed to skip useless characters
        /// </summary>
        /// <returns>returns the lenght of the markdown code of the image</returns>
        private int GetImageLenght()
        {
            try
            {
                string address = Text.Substring(index);
                return address.IndexOf(')');
            }
            catch { return 0; }
        }
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertImage()
        {
            try
            {
                if (Text[index + 1] == '[')
                {
                    string address = GetImageAddress().Trim();
                    string altText = GetImageText().Trim();
                    if (address == "" || altText == "")
                        return false;
                    skip = GetImageLenght();
                    if (beginningOfLine)
                        Html += @"<p><img src=""" + address + @"""" + @" alt=""" + altText + @""">";
                    else
                        Html += @"<img src=""" + address + @"""" + @" alt=""" + altText + @""">";
                    beginningOfLine = false;
                    return true;
                }
                else { return false; }
            }
            catch { return false; }

        }
        #endregion

        #region Code
        /// <summary>
        /// Adds html tags and removes unnecessary parts
        /// </summary>
        /// <returns>returns true if the conversion has concluded succesfully</returns>
        private bool ConvertCode()
        {
            try
            {
                if (Text[index + 1] == (char)39 && Text[index + 2] == (char)39)
                {
                    if (!codeActivated)
                    {
                        Html += "<p><pre><code>" + Environment.NewLine;
                        codeActivated = true;
                        beginningOfLine = false;
                    }
                    else
                    {
                        Html += Environment.NewLine + "</code></pre>";
                        codeActivated = false;
                        beginningOfLine = false;
                    }
                    skip = 3;
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }
        #endregion
    }
}
