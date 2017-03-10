using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TherapyItemRecSys.Classes
{
    class CBindDGRecCandidate : INotifyPropertyChanged
    {
        CRecCandidate m_recCandidate;
        private int m_intIdx;        

        List<CLexicalItem> m_lsLexicalItem;
        List<CChallengeItem> m_lsChallengeItem;
        List<CChallengeItemFeatures> m_lsChallengeItemFeatures;

        public event PropertyChangedEventHandler PropertyChanged;
        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        //----------------------------------------------------------------------------------------------------
        // CBindDGRecCandidate
        //----------------------------------------------------------------------------------------------------
        public CBindDGRecCandidate(int intI, CRecCandidate recCandidate, List<CLexicalItem> lsLexicalItem, List<CChallengeItem> lsChallengeItem, List<CChallengeItemFeatures> lsChallengeItemFeatures)
        {
            m_intIdx = intI;
            m_recCandidate = recCandidate;            
            m_lsLexicalItem = lsLexicalItem;
            m_lsChallengeItem = lsChallengeItem;
            m_lsChallengeItemFeatures = lsChallengeItemFeatures; 
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
                int intCiIdx = m_lsChallengeItemFeatures[this.m_recCandidate.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx;                
                string strName = m_lsChallengeItem[intCiIdx].m_strName;                
                return strName ;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("Name");
            }
        }

        /*public string LexicalItem
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
        }*/

        public int Frequency
        {
            get
            {
                int intCiIdx = m_lsChallengeItemFeatures[this.m_recCandidate.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                //int intIdx = m_lsChallengeItem[intCiIdx].m_intLexicalItemIdx;
                return this.m_lsChallengeItem[intCiIdx].m_intFrequency;
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
                int intCiIdx = m_lsChallengeItemFeatures[this.m_recCandidate.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                //int intIdx = m_lsChallengeItem[intCiIdx].m_intLexicalItemIdx;
                return this.m_lsChallengeItem[intCiIdx].m_intConcreteness;
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
                int intNum = 0;
                double dComplexityDistractorNum = m_lsChallengeItemFeatures[this.m_recCandidate.m_intChallengeItemFeaturesIdx].m_dComplexity_DistractorNum;
                if (dComplexityDistractorNum == 0.1)
                    intNum = 2;
                else if (dComplexityDistractorNum == 0.4)
                    intNum = 3;
                else if (dComplexityDistractorNum == 0.7)
                    intNum = 4;
                else if (dComplexityDistractorNum == 1)
                    intNum = 5;
                return intNum;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("DistractorNum");
            }
        }          

        public int NeighbourCtr
        {
            get
            {
                return this.m_recCandidate.m_intNeighbourForCtr;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("NeighbourCtr");
            }
        }

        public double SimilarityStrength
        {
            get
            {
                return this.m_recCandidate.m_dSimilarityStrength;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("SimilarityStrength");
            }
        }

        public double CurComplexity
        {
            get
            {
                return this.m_recCandidate.m_dCurComplexity;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("CurComplexity");
            }
        }

        public double ComplexityWeight
        {
            get
            {
                return this.m_recCandidate.m_dComplexityWeight;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ComplexityWeight");
            }
        }

        public double NeighbourWeight
        {
            get
            {
                return this.m_recCandidate.m_dNeighbourWeight;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("NeighbourWeight");
            }
        }

        public double ExposureWeight
        {
            get
            {
                return this.m_recCandidate.m_dExposureWeight;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("ExposureWeight");
            }
        }

        public double RecommendationStrength
        {
            get
            {
                return this.m_recCandidate.m_dRecommendationStrength;
            }
            set
            {
                //this.intIdx = value;
                OnPropertyChanged("RecommendationStrength");
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
