using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TherapyItemRecSys.Classes
{
    class CBindDGChallengeItemFeatures : INotifyPropertyChanged
    {
        CChallengeItemFeatures m_challengeItemFeatures;
        private int m_intIdx;
        public double m_dSimilarity = 0;
        
        List<CLexicalItem> m_lsLexicalItem;
        List<CChallengeItem> m_lsChallengeItem;

        public event PropertyChangedEventHandler PropertyChanged;
        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        //----------------------------------------------------------------------------------------------------
        // CBindDGCifNeighbours
        //----------------------------------------------------------------------------------------------------
        public CBindDGChallengeItemFeatures(int intI, CChallengeItemFeatures challengeItemFeatures, double dSimilarity, List<CLexicalItem> lsLexicalItem, List<CChallengeItem> lsChallengeItem)
        {
            m_intIdx = intI;
            m_challengeItemFeatures = challengeItemFeatures;
            m_dSimilarity = dSimilarity;            
            m_lsLexicalItem = lsLexicalItem;
            m_lsChallengeItem = lsChallengeItem;
        }

        //----------------------------------------------------------------------------------------------------
        // Getters and Setters
        //----------------------------------------------------------------------------------------------------
        #region Properties Getters and Setters
        public int Idx
        {
            get { return this.m_intIdx; }
            set
            {
                this.m_intIdx = value;
                OnPropertyChanged("Idx");
            }
        }

        public string Name
        {
            get
            {
                string strName = m_lsChallengeItem[m_challengeItemFeatures.m_intChallengeItemIdx].m_strName;
                return strName + " ( " + m_challengeItemFeatures.m_intDistractorNum + " )";
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("Name");
            }
        }

        public string LexicalItem
        {
            get
            {
                int intIdx = m_lsChallengeItem[m_challengeItemFeatures.m_intChallengeItemIdx].m_intLexicalItemIdx;
                return this.m_lsLexicalItem[intIdx].m_strName;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("LexicalItem");
            }
        }

        public int Frequency
        {
            get
            {
                return this.m_challengeItemFeatures.m_intFrequency;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("Frequency");
            }
        }

        public int Concreteness
        {
            get
            {
                return this.m_challengeItemFeatures.m_intConcreteness;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("Concreteness");
            }
        }

        public int DistractorNum
        {
            get
            {                
                return this.m_challengeItemFeatures.m_intDistractorNum;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("DistractorNum");
            }
        }

        public int LinguisticCategory
        {
            get
            {
                return this.m_challengeItemFeatures.m_intLinguisticCategory;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("LinguisticCategory");
            }
        }

        public string LinguisticCategoryStr
        {
            get
            {
                string str = Enum.GetName(typeof(CConstants.g_LinguisticCategory), this.m_challengeItemFeatures.m_intLinguisticCategory);
                return str;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("LinguisticCategoryStr");
            }
        }

        public int LinguisticType
        {
            get
            {
                return this.m_challengeItemFeatures.m_intLinguisticType;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("LinguisticType");
            }
        }

        public double ComplexityFreq
        {
            get
            {
                return this.m_challengeItemFeatures.m_dComplexity_Frequency;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityFreq");
            }
        }

        public double ComplexityConc
        {
            get
            {
                return this.m_challengeItemFeatures.m_dComplexity_Concreteness;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityConc");
            }
        }

        public double ComplexityDistr
        {
            get
            {
                return this.m_challengeItemFeatures.m_dComplexity_DistractorNum;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityDistr");
            }
        }

        public double ComplexityLT
        {
            get
            {
                return this.m_challengeItemFeatures.m_dComplexity_LinguisticType;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityLT");
            }
        }

        public double ComplexityOverall
        {
            get
            {
                return this.m_challengeItemFeatures.m_dComplexity_Overall;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityOverall");
            }
        }

        public double Similarity
        {
            get
            {
                return this.m_dSimilarity;
            }
            set
            {
                OnPropertyChanged("Similarity");
            }
        }        

        #endregion

        //----------------------------------------------------------------------------------------------------
        // OnPropertyChanged
        //----------------------------------------------------------------------------------------------------
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
