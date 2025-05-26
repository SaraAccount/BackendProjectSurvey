using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum eTypeTag
    {
        INPUT_TEXT,
        INPUT_NUMBER,
        CHECKBOX,
        SELECT,
        RADIO
    }
    public class Question
    {
        //properties
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public eTypeTag TypeTag { get; set; }
        public bool IsRequired { get; set; } //must 
        public string Options { get; set; }
        public virtual ICollection<Answer>? Answers { get; set; }

        //functions
        //פונקציה שתחלץ את המחרוזות ותהפוך את זה לרשימה של מחרוזות
        //להעביר את זה לservice
        public string RenderHtml()
        {
            string requiredAttr = IsRequired ? "required" : "";

            switch (TypeTag)
            {
                case eTypeTag.INPUT_TEXT:
                    return $"<label for='{Id}'>{Label}</label><input type='text' id='{Id}' name='{Id}' {requiredAttr}>";

                case eTypeTag.INPUT_NUMBER:
                    return $"<label for='{Id}'>{Label}</label><input type='number' id='{Id}' name='{Id}' {requiredAttr}>";

                case eTypeTag.CHECKBOX:
                    return $"<label for='{Id}'>{Label}</label><input type='checkbox' id='{Id}' name='{Id}' {requiredAttr}>";

                case eTypeTag.RADIO:
                    if (Options == null) return "";
                    return $"<label>{Label}</label>" + string.Join("", Options.Select(opt =>
                        $"<input type='radio' name='{Id}' value='{opt}' {requiredAttr}> {opt}"));

                case eTypeTag.SELECT:
                    if (Options == null) return "";
                    return $"<label for='{Id}'>{Label}</label><select id='{Id}' name='{Id}' {requiredAttr}>" +
                           string.Join("", Options.Select(opt => $"<option value='{opt}'>{opt}</option>")) + "</select>";
                default:
                    return $"<p>Unsupported question type: {TypeTag}</p>";
            }

        }








        }
}
