using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TherapyItemRecSys.Classes;
using System.Collections.ObjectModel;

namespace TherapyItemRecSys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CDataset m_dataset = new CDataset();
        CRecommender m_recommender = new CRecommender();
        List<CLexicalItem> m_lsLexicalItem;
        List<CChallengeItem> m_lsChallengeItem;
        List<CChallengeItemFeatures> m_lsChallengeItemFeatures;

        //----------------------------------------------------------------------------------------------------
        // MainWindow
        //----------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            CCsvXmlTool tool = new CCsvXmlTool();
            //tool.convertCsvToXml();
            //tool.calculateNeighbours();
            //tool.directoryCopy("audio/", "audio_all/", true);
            //tool.checkAudioImage();
            //tool.generateStarterPool();
            //tool.generateMedianPool();
            //tool.testCosineSimilarity();

       /*     m_dataset.loadDataset(1);
            m_recommender.init("", "002b2", 1);

            // print lexical items
            string str = "";
            m_lsLexicalItem = m_dataset.getLexicalItemList();
            for (int i = 0; i < m_lsLexicalItem.Count; i++)
                str = str + i + " - " + m_lsLexicalItem[i].m_strName + "\n";
            tbLexicalItems.Text = str;

            // print challenge items
            str = "";
            m_lsChallengeItem = m_dataset.getChallengeItemList();
            for (int i = 0; i < m_lsChallengeItem.Count; i++)
                str = str + i + " - " + m_lsChallengeItem[i].m_strName + "-" + m_lsChallengeItem[i].m_intFrequency + "-" + m_lsChallengeItem[i].m_intConcreteness + "\n"; 
            tbChallengeItems.Text = str;

            m_lsChallengeItemFeatures = m_dataset.getChallengeItemFeaturesList();

            // tab 2 - show feature list
            showDatagridTab2_Cif();
            
            // tab 3 - show forced items      
            showForcedItems();*/
        }

        //----------------------------------------------------------------------------------------------------
        // btnConvertCsvToXml_Click
        //----------------------------------------------------------------------------------------------------
        private void btnConvertCsvToXml_Click(object sender, RoutedEventArgs e)
        {
            CCsvXmlTool tool = new CCsvXmlTool();
            tool.convertCsvToXml();
        }

        //----------------------------------------------------------------------------------------------------
        // btnCalculateNeighbours_Click
        //----------------------------------------------------------------------------------------------------
        private void btnCalculateNeighbours_Click(object sender, RoutedEventArgs e)
        {
            CCsvXmlTool tool = new CCsvXmlTool();
            tool.calculateNeighbours();
        }

        //----------------------------------------------------------------------------------------------------
        // btnGenerateStarterPool_Click
        //----------------------------------------------------------------------------------------------------
        private void btnGenerateStarterPool_Click(object sender, RoutedEventArgs e)
        {
            CCsvXmlTool tool = new CCsvXmlTool();
            tool.generateStarterPool();
        }

        //----------------------------------------------------------------------------------------------------
        // btnNextBlock_Click
        //----------------------------------------------------------------------------------------------------
        private void btnNextBlock_Click(object sender, RoutedEventArgs e)
        {
            // update user's history - simulate responses
            lbResponse.Content = "";
            Random rnd = new Random();
            List<int> lsResponse = new List<int>();
            for (int i = 0; i < CConstants.g_intItemNumPerBlock; i++)
            {
                lsResponse.Add(1); // rnd.Next(0, 2)); // random 0, 1
                //lbResponse.Content = lbResponse.Content + lsResponse[lsResponse.Count - 1].ToString() + ", ";
                //Console.WriteLine(lsResponse[lsResponse.Count - 1]);
            }
            // simulate 30% correct
            //lsResponse[0] = 1; lsResponse[2] = 1; lsResponse[10] = 1;
            // simulate 70% correct, 30% incorrect
            /*int intNum = (int)(lsResponse.Count * 0.3);
            int intCtr = 0;
            while (intCtr < intNum)
            {
                int intIdx = rnd.Next(0, lsResponse.Count);
                if (lsResponse[intIdx] != 0)
                {
                    lsResponse[intIdx] = 0;
                    intCtr++;
                }
            }*/
            
            // simulate 60%-80% correct, 20%-40% incorrect
            // random.NextDouble() * (maximum - minimum) + minimum;
            /*double dRnd = rnd.NextDouble() * (0.71 - 0.2) + 0.2;
            int intNum = (int)(lsResponse.Count * dRnd);
            int intCtr = 0;
            while (intCtr < intNum)
            {
                int intIdx = rnd.Next(0, lsResponse.Count);
                if (lsResponse[intIdx] != 0)
                {
                    lsResponse[intIdx] = 0;
                    intCtr++;
                }
            }*/

            m_recommender.updateUserHistory(lsResponse);

            for (int i = 0; i < lsResponse.Count; i++)
                lbResponse.Content = lbResponse.Content + lsResponse[i].ToString() + ", ";

            // present next block
            List<int> lsIdx = m_recommender.getNextBlock();
            Console.WriteLine("num items = " + lsIdx.Count);

            lbResponse.Content = lbResponse.Content + "\nnoise level = " + m_recommender.getCurNoiseLevel() + 
                                    "; predicted user ability = " + m_recommender.getCurBlockUserAbility() +
                                    "\nblock type = " + m_recommender.getCurBlockType();

            if (lsIdx.Count < CConstants.g_intItemNumPerBlock)
            {
                //m_recommender.resetUserProfile();
                //lsIdx = m_recommender.getNextBlock();
                lbResponse.Content = lbResponse.Content + "\nEND!!!";
                return;
            }
            string str = ""; tbNextBlock.Text = "";
            for (int i = 0; i < lsIdx.Count; i++)
            {
                int intChallengeItemIdx = m_lsChallengeItemFeatures[lsIdx[i]].m_intChallengeItemIdx;
                int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;
                str = str + i + " - " + m_lsChallengeItem[intChallengeItemIdx].m_strName +
                        "-" + m_lsChallengeItem[intChallengeItemIdx].m_intFrequency +
                        "-" + m_lsChallengeItem[intChallengeItemIdx].m_intConcreteness + 
                        "-" + convertDistractorNum(m_lsChallengeItemFeatures[lsIdx[i]].m_dComplexity_DistractorNum) +
                        /*"-" + m_lsChallengeItemFeatures[lsIdx[i]].m_dComplexity_LinguisticCategory + 
                        "-" + m_lsChallengeItemFeatures[lsIdx[i]].m_dComplexity_NoiseLevel +*/ "\n";
            }
            tbNextBlock.Text = str;

            // print rec candidates
            ObservableCollection<CBindDGRecCandidate> lsBindRecCandidate = new ObservableCollection<CBindDGRecCandidate>();
            List<CRecCandidate> lsRecCandidate = m_recommender.getCurrentBlock_RecCandidateList_Word();
            for (int i = 0; i < lsRecCandidate.Count; i++)
            {
                CBindDGRecCandidate item = new CBindDGRecCandidate(i, lsRecCandidate[i], m_lsLexicalItem, m_lsChallengeItem, m_lsChallengeItemFeatures);
                lsBindRecCandidate.Add(item);                
            }
            dgRecCandidatesWord.ItemsSource = lsBindRecCandidate;
            dgRecCandidatesWord.DataContext = lsBindRecCandidate;
            dgRecCandidatesWord.Items.Refresh();


            /*str = ""; tbRecCandidatesWord.Text = "";
            List<CRecCandidate> lsRecCandidate = m_recommender.getCurrentBlock_RecCandidateList_Word();
            for (int i = 0; i < lsRecCandidate.Count; i++)
            {
                if (lsRecCandidate[i].m_dRecommendationStrength > 0)
                {
                    int intChallengeItemFeaturesIdx = lsRecCandidate[i].m_intChallengeItemFeaturesIdx;
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;

                    str = str + i + " " + m_lsChallengeItem[intChallengeItemIdx].m_strName + " - ";
                    str = str + m_lsLexicalItem[intLexicalItemIdx].m_intFrequency + "-" + m_lsLexicalItem[intLexicalItemIdx].m_intConcreteness +
                            "-" + convertDistractorNum(m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_dComplexity_DistractorNum) + "\n";
                    str = str + "ctr-" + lsRecCandidate[i].m_intNeighbourForCtr + ", ";
                    str = str + "nei-" + lsRecCandidate[i].m_dNeighbourWeight + ", ";
                    str = str + "exp-" + lsRecCandidate[i].m_dExposureWeight + ", ";
                    str = str + "sim-" + lsRecCandidate[i].m_dSimilarityStrength + ", ";
                    str = str + "cpx-" + lsRecCandidate[i].m_dCurComplexity + ", ";
                    str = str + "rs-" + lsRecCandidate[i].m_dRecommendationStrength + "\n\n";
                }
            }
            tbRecCandidatesWord.Text = str;*/

            str = ""; tbRecCandidatesESentence.Text = "";
            lsRecCandidate = m_recommender.getCurrentBlock_RecCandidateList_ESentence();
            //Console.WriteLine("num of easy sentence = " + lsRecCandidate.Count);
            for (int i = 0; i < lsRecCandidate.Count; i++)
            {
                if (lsRecCandidate[i].m_dRecommendationStrength > 0)
                {
                    int intChallengeItemFeaturesIdx = lsRecCandidate[i].m_intChallengeItemFeaturesIdx;
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;

                    str = str + i + " " + m_lsChallengeItem[intChallengeItemIdx].m_strName + " - ";
                    str = str + m_lsChallengeItem[intChallengeItemIdx].m_intFrequency + "-" + m_lsChallengeItem[intChallengeItemIdx].m_intConcreteness +
                            "-" + convertDistractorNum(m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_dComplexity_DistractorNum) + "\n";
                    str = str + "ctr-" + lsRecCandidate[i].m_intNeighbourForCtr + ", ";
                    str = str + "nei-" + lsRecCandidate[i].m_dNeighbourWeight + ", ";
                    str = str + "exp-" + lsRecCandidate[i].m_dExposureWeight + ", ";
                    str = str + "sim-" + lsRecCandidate[i].m_dSimilarityStrength + ", ";
                    str = str + "cpx-" + lsRecCandidate[i].m_dCurComplexity + ", ";
                    str = str + "rs-" + lsRecCandidate[i].m_dRecommendationStrength + "\n\n";
                }
            }
            tbRecCandidatesESentence.Text = str;

            str = ""; tbRecCandidatesHSentence.Text = "";
            lsRecCandidate = m_recommender.getCurrentBlock_RecCandidateList_HSentence();
            for (int i = 0; i < lsRecCandidate.Count; i++)
            {
                if (lsRecCandidate[i].m_dRecommendationStrength > 0)
                {
                    int intChallengeItemFeaturesIdx = lsRecCandidate[i].m_intChallengeItemFeaturesIdx;
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;

                    str = str + i + " " + m_lsChallengeItem[intChallengeItemIdx].m_strName + " - ";
                    str = str + m_lsChallengeItem[intChallengeItemIdx].m_intFrequency + "-" + m_lsChallengeItem[intChallengeItemIdx].m_intConcreteness +
                            "-" + convertDistractorNum(m_lsChallengeItemFeatures[intChallengeItemFeaturesIdx].m_dComplexity_DistractorNum) + "\n";
                    str = str + "ctr-" + lsRecCandidate[i].m_intNeighbourForCtr + ", ";
                    str = str + "nei-" + lsRecCandidate[i].m_dNeighbourWeight + ", ";
                    str = str + "exp-" + lsRecCandidate[i].m_dExposureWeight + ", ";
                    str = str + "sim-" + lsRecCandidate[i].m_dSimilarityStrength + ", ";
                    str = str + "cpx-" + lsRecCandidate[i].m_dCurComplexity + ", ";
                    str = str + "rs-" + lsRecCandidate[i].m_dRecommendationStrength + "\n\n";
                }
            }
            tbRecCandidatesHSentence.Text = str;

            // print history
            str = "";
            CUser_TherapyBlock lastTherapyBlock = m_recommender.getLastTherapyBlock();
            if (lastTherapyBlock != null)
            {
                /*for (int i = 0; i < lastTherapyBlock.m_lsChallengeItemFeaturesIdx.Count; i++)
                {
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[lastTherapyBlock.m_lsChallengeItemFeaturesIdx[i]].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;
                    str = str + lastTherapyBlock.m_lsResponseAccuracy[i] + " - " + m_lsChallengeItem[intChallengeItemIdx].m_strName +
                            "-" + m_lsLexicalItem[intLexicalItemIdx].m_intFrequency +
                            "-" + m_lsLexicalItem[intLexicalItemIdx].m_intConcreteness +
                            "-" + convertDistractorNum(m_lsChallengeItemFeatures[lsIdx[i]].m_dComplexity_DistractorNum) + "\n";

                }*/

                str = str + "noise=" + lastTherapyBlock.m_intNoiseLevel + ", bType=" + lastTherapyBlock.m_intBlockType + "\n";
                str = str + "acc = " + lastTherapyBlock.m_dAccuracyRate + ",  uab = " + lastTherapyBlock.m_dUserAbility_Accumulated +
                    ",  m(f) = " + lastTherapyBlock.m_dMean_Frequency + ", sd(f) = " + lastTherapyBlock.m_dStdDeviation_Frequency +
                    ",  m(c) = " + lastTherapyBlock.m_dMean_Concreteness + ", sd(c) = " + lastTherapyBlock.m_dStdDeviation_Concreteness +
                    ",  m(d) = " + lastTherapyBlock.m_dMean_DistractorNum + ", sd(d) = " + lastTherapyBlock.m_dStdDeviation_DistractorNum + "\n\n";
            }
            /*for (int i = 0; i < lsIdx.Count; i++)
            {
                int intChallengeItemIdx = m_lsChallengeItemFeatures[lsIdx[i]].m_intChallengeItemIdx;
                int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;
                str = str + i + " - " + m_lsChallengeItem[intChallengeItemIdx].m_strName +
                        "-" + m_lsLexicalItem[intLexicalItemIdx].m_intFrequency +
                        "-" + m_lsLexicalItem[intLexicalItemIdx].m_intConcreteness +
                        "-" + convertDistractorNum(m_lsChallengeItemFeatures[lsIdx[i]].m_dComplexity_DistractorNum) + " | ";
            }*/
            tbHistory.Text = tbHistory.Text + "\n" + str;
        }

        //----------------------------------------------------------------------------------------------------
        // convertDistractorNum
        //----------------------------------------------------------------------------------------------------
        private int convertDistractorNum(double dComplexityDistractorNum)
        {
            int intNum = 0;
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

        //----------------------------------------------------------------------------------------------------
        // showDatagridTab2_Cif
        //----------------------------------------------------------------------------------------------------
        private void showDatagridTab2_Cif()
        {
            ObservableCollection<CBindDGChallengeItemFeatures> lsBindCif = new ObservableCollection<CBindDGChallengeItemFeatures>();

            for (int i = 0; i < m_lsChallengeItemFeatures.Count; i++)
            {
                CBindDGChallengeItemFeatures item = new CBindDGChallengeItemFeatures(i, m_lsChallengeItemFeatures[i], 0, m_lsLexicalItem, m_lsChallengeItem);
                lsBindCif.Add(item);
            }
            dgTab2_Cif.ItemsSource = lsBindCif;
            dgTab2_Cif.DataContext = lsBindCif;
            dgTab2_Cif.Items.Refresh();            
        }

        //----------------------------------------------------------------------------------------------------
        // dgTab2_Cif_SelectionChanged
        //----------------------------------------------------------------------------------------------------
        private void dgTab2_Cif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            CBindDGChallengeItemFeatures cifSelected = ((DataGrid)sender).SelectedItem as CBindDGChallengeItemFeatures;
            //MessageBox.Show(cif.Idx.ToString());

            if (cifSelected != null)
            {
                List<CVector_ChallengeItemFeaturesNeighbours> lsVector_Neighbours = m_dataset.getVectorNeighboursList();
                List<CChallengeItemFeatures_Neighbour> lsNeighbour = lsVector_Neighbours[cifSelected.Idx].m_lsChallengeItemFeatures_Neighbour;

                ObservableCollection<CBindDGChallengeItemFeatures> lsBindCifNeighbours = new ObservableCollection<CBindDGChallengeItemFeatures>();

                for (int i = 0; i < lsNeighbour.Count; i++)
                {
                    CChallengeItemFeatures_Neighbour neighbour = lsNeighbour[i];

                    CBindDGChallengeItemFeatures item = new CBindDGChallengeItemFeatures(i, m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx], neighbour.m_dSimilarity, m_lsLexicalItem, m_lsChallengeItem);
                    lsBindCifNeighbours.Add(item);
                }

                dgTab2_CifNeighbours.ItemsSource = lsBindCifNeighbours;
                dgTab2_CifNeighbours.DataContext = lsBindCifNeighbours;
                dgTab2_CifNeighbours.Items.Refresh();
            }
        }

        //----------------------------------------------------------------------------------------------------
        // showForcedItems
        //----------------------------------------------------------------------------------------------------
        private void showForcedItems()
        {
            int intCtrA = 0;
            int intCtrB = 0;
            
            for (int i = 0; i<m_lsChallengeItem.Count; i++)
            {
                if ((m_lsChallengeItem[i].m_intForcedItem == 1) /*&& (cbi.Content.ToString().Equals("set A"))*/)
                {
                    intCtrA++;
                    lbForcedItemSetA.Items.Add(intCtrA + " - " + i + " - " + m_lsChallengeItem[i].m_strLinguisticCategoryName + " - " + m_lsChallengeItem[i].m_strName);
                }
                /*if ((m_lsChallengeItem[i].m_intForcedItem == 1) && (cbi.Content.ToString().Equals("set B")))
                {
                    intCtrB++;
                    lbForcedItemSetB.Items.Add(intCtrB + " - " + i + " - " + m_lsChallengeItem[i].m_strLinguisticCategoryName + " - " + m_lsChallengeItem[i].m_strName);
                }*/
            }
        }

        
    }
}
