using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Model
{

    public class ReturnList
    {
        private string conditionSeparator = "; ";
        private string referenceSeparator = ",";
        //public double Similarity;
        public bool HasCAS;
        public bool IsDeprotection;
        public bool HasRegioError;

        
        public float yield { set; get; }

        
        public int reactionID { set; get; }

        
        public int citationID { set; get; }

        /// <summary>
        /// 步骤
        /// </summary>
        
        public string procedure { set; get; }

        /// <summary>
        /// 参考
        /// </summary>
        
        public string reference { set; get; }

        
        public string rxnsmiles { set; get; }

        
        public int isMore { set; get; }

        
        public int RetroReactionID { set; get; }

        
        public int Steps { set; get; }

        
        public List<Reaction> reactionObject { set; get; }

        public int Score { set; get; }

        
        public int CanMake { set; get; }

        public bool HasPrice { set; get; }

        
        public decimal TotalPrice { set; get; }

        public string condition { set; get; }

        public int ConditionCount { set; get; }

        public int Count { set; get; }
        public int TotalCount { set; get; }

        public string XianShiReference
        {
            get
            {
                return TrimReference(reference);
            }
        }

        public string XianShiCondition
        {
            get
            {
                if (condition.EndsWith("|"))
                {
                    condition = (condition.Substring(0, condition.Length - 1));
                }
                return condition = condition.Replace("|", conditionSeparator);
            }
        }

    
        public string ProductSmiles { set; get; }

        private string TrimReference(string refstring)
        {
            if (string.IsNullOrEmpty(refstring))
                return "";
            string[] elements = refstring.Split(';');
            if (elements.Length < 2) return refstring;
            StringBuilder sb = new StringBuilder();
            bool beginAppend = false;
            for (int i = 1; i < elements.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(elements[i]))
                    continue;
                if (!beginAppend && Regex.IsMatch(elements[i], "\\d"))
                {
                    sb.Append(elements[i - 1] + referenceSeparator);
                    beginAppend = true;
                }
                if (beginAppend)
                    sb.Append(elements[i] + referenceSeparator);
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public ReturnList Clone()
        {
            ReturnList entity = new ReturnList();
            entity.procedure = procedure;
            entity.reference = reference;
            entity.rxnsmiles = rxnsmiles;
            entity.yield = yield;
            entity.condition = condition;
            entity.reactionID = reactionID;
            entity.citationID = citationID;
            entity.RetroReactionID = RetroReactionID;
            entity.Steps = Steps;
            return entity;
        }
    }
    public class Reaction
    {
        
        public string smiles { set; get; }

        
        public string cas { set; get; }

        public int chemicalID { set; get; }

        
        public double molMass { set; get; }

        //
        //public decimal price { set; get; }
        //
        //public string unit { set; get; }
        
        public int hasPrice { set; get; }

        public int canMake { set; get; }
        public int HasSupplier { set; get; }
        public decimal MolPrice { set; get; }

        
        public int MoleculeID { set; get; }
    }
}
