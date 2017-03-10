using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.IO;

namespace TherapyItemRecSys.Classes
{
    class CCsvXmlTool
    {
        List<CLexicalItem> m_lsLexicalItem = new List<CLexicalItem>();
        List<CChallengeItem> m_lsChallengeItem = new List<CChallengeItem>();
        List<CChallengeItemFeatures> m_lsChallengeItemFeatures = new List<CChallengeItemFeatures>();
        List<CVector_ChallengeItemFeaturesNeighbours> m_lsVector_Neighbours = new List<CVector_ChallengeItemFeaturesNeighbours>();
        List<int> m_lsChallengeItemFeatures_Forced = new List<int>();

        /*string m_strFile_LexicalItem_Xml = "stimuli_lexicalitems_all.xml"; //"stimuli_noun_verb_lexicalitems.xml";
        string m_strFile_ChallengeItem_Xml = "stimuli_challengeitems_all.xml"; //"stimuli_noun_verb_challengeitems.xml";
        string m_strFile_ChallengeItemFeature_Csv = "stimuli_challengeitemfeatures_all.csv"; //"stimuli_noun_verb_challengeitemfeatures.csv";
        string m_strFile_ChallengeItemFeature_Neighbours_Csv = "stimuli_challengeitemfeatures_neighbours_all.csv";  //"stimuli_noun_verb_challengeitemfeatures_neighbours.csv";
        */
        
        
        /*string m_strFile_LexicalItem_Xml = "setA_stimuli_lexicalitems_all.xml"; 
        string m_strFile_ChallengeItem_Xml = "setA_stimuli_challengeitems_all.xml"; 
        string m_strFile_ChallengeItemFeature_Csv = "setA_stimuli_challengeitemfeatures_all.csv"; 
        string m_strFile_ChallengeItemFeature_Neighbours_Csv = "setA_stimuli_challengeitemfeatures_neighbours_all_30.csv";
        string m_strFile_ChallengeItemFeature_Starterpool_Csv = "setA_stimuli_challengeitemfeatures_starterpool.csv";
        string m_strFile_ChallengeItemFeature_Medianpool_Csv = "setA_stimuli_challengeitemfeatures_medianpool.csv";*/
        
        string m_strFile_LexicalItem_Xml = "setB_stimuli_lexicalitems_all.xml";
        string m_strFile_ChallengeItem_Xml = "setB_stimuli_challengeitems_all.xml";
        string m_strFile_ChallengeItemFeature_Csv = "setB_stimuli_challengeitemfeatures_all.csv";
        string m_strFile_ChallengeItemFeature_Neighbours_Csv = "setB_stimuli_challengeitemfeatures_neighbours_all_30.csv";
        string m_strFile_ChallengeItemFeature_Starterpool_Csv = "setB_stimuli_challengeitemfeatures_starterpool.csv";
        string m_strFile_ChallengeItemFeature_Medianpool_Csv = "setB_stimuli_challengeitemfeatures_medianpool.csv";

        //----------------------------------------------------------------------------------------------------
        // CCsvXmlTool
        //----------------------------------------------------------------------------------------------------
        public CCsvXmlTool()
        {
        }

        //----------------------------------------------------------------------------------------------------
        // ConvertCsvToXml
        //----------------------------------------------------------------------------------------------------
        public void convertCsvToXml()
        {
            // initialize
            m_lsLexicalItem.Clear();
            m_lsChallengeItem.Clear();
            //m_lsChallengeItem_NeighbourList.Clear();

            // set A
            /*readCsv("stimuli_setA/setA_7_Noun_1syll_word_csv.csv", 0, "noun_1syll_word");
            readCsv("stimuli_setA/setA_7_Noun_1syll_phrase_csv.csv", 0, "noun_1syll_phrase");
            readCsv("stimuli_setA/setA_8_Noun_2syll_word_csv.csv", 0, "noun_2syll_word");
            readCsv("stimuli_setA/setA_8_Noun_2syll_phrase_csv.csv", 0, "noun_2syll_phrase");
            readCsv("stimuli_setA/setA_9_Noun_3syll_word_csv.csv", 0, "noun_3syll_word");
            readCsv("stimuli_setA/setA_9_Noun_3syll_phrase_csv.csv", 0, "noun_3syll_phrase");
            
            readCsv("stimuli_setA/setA_10_Noun_attributive_csv.csv", 0, "noun_attributive");
            readCsv("stimuli_setA/setA_11_Noun_predicative_csv.csv", 1, "noun_predicative");
            readCsv("stimuli_setA/setA_12_Noun_Intransitive_csv.csv", 1, "noun_intransitive");

            readCsv("stimuli_setA/setA_1_Noun_IntransitivePPbeg_csv.csv", 2, "noun_intransitivePPbeg");
            readCsv("stimuli_setA/setA_2_Noun_IntransitivePPend_csv.csv", 2, "noun_intransitivePPend");
            readCsv("stimuli_setA/setA_3_Noun_transitive_beg_csv.csv", 2, "noun_transitive_beg");
            readCsv("stimuli_setA/setA_4_Noun_transitive_end_csv.csv", 2, "noun_transitive_end");
            readCsv("stimuli_setA/setA_5_Noun_TransitivePP_csv.csv", 2, "noun_transitivePP");            
            readCsv("stimuli_setA/setA_6_Noun_Ditransitive_csv.csv", 2, "noun_ditransitive");            
            
            
            readCsv("stimuli_setA/setA_13_Prep_Phrase_csv.csv", 1, "prep_phrase");
            readCsv("stimuli_setA/setA_14_Prep_Sentence_csv.csv", 2, "prep_sentence");

            readCsv("stimuli_setA/setA_15_PRN_Possessive_sentences_csv.csv", 1, "prn_possessive_sentences");
            readCsv("stimuli_setA/setA_16_PRN_Possessive_csv.csv", 1, "prn_possessive");
            readCsv("stimuli_setA/setA_17_PRN_Personal_csv.csv", 1, "prn_personal");

            readCsv("stimuli_setA/setA_18_Tense_Simple_csv.csv", 2, "tense_simple");
            readCsv("stimuli_setA/setA_19_Tense_Progressive_csv.csv", 2, "tense_progressive");

            readCsv("stimuli_setA/setA_20_Verb_Intransitive_csv.csv", 1, "verb_intransitive");
            readCsv("stimuli_setA/setA_21_Verb_IntransitivePP_csv.csv", 2, "verb_intransitivePP");
            readCsv("stimuli_setA/setA_22_Verb_Transitive_csv.csv", 2, "verb_transitive");
            readCsv("stimuli_setA/setA_23_Verb_Ditransitive_csv.csv", 2, "verb_ditransitive");
            readCsv("stimuli_setA/setA_24_Verb_TransitivePP_csv.csv", 2, "verb_transitivePP");

            readCsv("stimuli_setA/setA_25_Adj_Phrase_csv.csv", 1, "adj_phrase");
            readCsv("stimuli_setA/setA_26_Adj_Sentence_csv.csv", 1, "adj_sentence");
            readCsv("stimuli_setA/setA_27_Adj_Intrans_sent_csv.csv", 2, "adj_intrans_sent");*/

            // set A
  /*          readCsv("stimuli_setA/setA_7_Noun_1syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_1syll_word);
            readCsv("stimuli_setA/setA_7_Noun_1syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_1syll_phrase);
            readCsv("stimuli_setA/setA_8_Noun_2syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_2syll_word);
            readCsv("stimuli_setA/setA_8_Noun_2syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_2syll_phrase);
            readCsv("stimuli_setA/setA_9_Noun_3syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_3syll_word);
            readCsv("stimuli_setA/setA_9_Noun_3syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_3syll_phrase);

            readCsv("stimuli_setA/setA_10_Noun_attributive_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_attributive);
            readCsv("stimuli_setA/setA_11_Noun_predicative_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.noun_predicative);
            readCsv("stimuli_setA/setA_12_Noun_Intransitive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.noun_intransitive);

            readCsv("stimuli_setA/setA_1_Noun_IntransitivePPbeg_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_intransitivePPbeg);
            readCsv("stimuli_setA/setA_2_Noun_IntransitivePPend_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_intransitivePPend);
            readCsv("stimuli_setA/setA_3_Noun_transitive_beg_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitive_beg);
            readCsv("stimuli_setA/setA_4_Noun_transitive_end_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitive_end);
            readCsv("stimuli_setA/setA_5_Noun_TransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitivePP);
            readCsv("stimuli_setA/setA_6_Noun_Ditransitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_ditransitive);


            readCsv("stimuli_setA/setA_13_Prep_Phrase_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prep_phrase);
            readCsv("stimuli_setA/setA_14_Prep_Sentence_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.prep_sentence);

            readCsv("stimuli_setA/setA_15_PRN_Possessive_sentences_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_possessive_sentences);
            readCsv("stimuli_setA/setA_16_PRN_Possessive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_possessive);
            readCsv("stimuli_setA/setA_17_PRN_Personal_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_personal);

            readCsv("stimuli_setA/setA_18_Tense_Simple_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.tense_simple);
            readCsv("stimuli_setA/setA_19_Tense_Progressive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.tense_progressive);

            readCsv("stimuli_setA/setA_20_Verb_Intransitive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.verb_intransitive);
            readCsv("stimuli_setA/setA_21_Verb_IntransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_intransitivePP);
            readCsv("stimuli_setA/setA_22_Verb_Transitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_transitive);
            readCsv("stimuli_setA/setA_23_Verb_Ditransitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_ditransitive);
            readCsv("stimuli_setA/setA_24_Verb_TransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_transitivePP);

            readCsv("stimuli_setA/setA_25_Adj_Phrase_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.adj_phrase);
            readCsv("stimuli_setA/setA_26_Adj_Sentence_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.adj_sentence);
            readCsv("stimuli_setA/setA_27_Adj_Intrans_sent_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.adj_intrans_sent);
            
            saveLexicalItemsToXml("setA_stimuli_lexicalitems_all.xml");
            saveChallengeItemsToXml("setA_stimuli_challengeitems_all.xml");
            saveChallengeItemFeaturesToCsv("setA_stimuli_challengeitemfeatures_all.csv");
            saveChallengeItemFeaturesForcedToCsv("setA_stimuli_challengeitemfeatures_forced_all.csv");
*/
            // set B
            /*readCsv("stimuli_setB/setB_7_Noun_1syll_word_csv.csv", 0, "noun_1syll_word");
            readCsv("stimuli_setB/setB_7_Noun_1syll_phrase_csv.csv", 0, "noun_1syll_phrase");
            readCsv("stimuli_setB/setB_8_Noun_2syll_word_csv.csv", 0, "noun_2syll_word");
            readCsv("stimuli_setB/setB_8_Noun_2syll_phrase_csv.csv", 0, "noun_2syll_phrase");
            readCsv("stimuli_setB/setB_9_Noun_3syll_word_csv.csv", 0, "noun_3syll_word");
            readCsv("stimuli_setB/setB_9_Noun_3syll_phrase_csv.csv", 0, "noun_3syll_phrase");

            readCsv("stimuli_setB/setB_10_Noun_attributive_csv.csv", 0, "noun_attributive");
            readCsv("stimuli_setB/setB_11_Noun_predicative_csv.csv", 1, "noun_predicative");
            readCsv("stimuli_setB/setB_12_Noun_Intransitive_csv.csv", 1, "noun_intransitive");

            readCsv("stimuli_setB/setB_1_Noun_IntransitivePPbeg_csv.csv", 2, "noun_intransitivePPbeg");
            readCsv("stimuli_setB/setB_2_Noun_IntransitivePPend_csv.csv", 2, "noun_intransitivePPend");
            readCsv("stimuli_setB/setB_3_Noun_transitive_beg_csv.csv", 2, "noun_transitive_beg");
            readCsv("stimuli_setB/setB_4_Noun_transitive_end_csv.csv", 2, "noun_transitive_end");
            readCsv("stimuli_setB/setB_5_Noun_TransitivePP_csv.csv", 2, "noun_transitivePP");
            readCsv("stimuli_setB/setB_6_Noun_Ditransitive_csv.csv", 2, "noun_ditransitive");


            readCsv("stimuli_setB/setB_13_Prep_Phrase_csv.csv", 1, "prep_phrase");
            readCsv("stimuli_setB/setB_14_Prep_Sentence_csv.csv", 2, "prep_sentence");

            readCsv("stimuli_setB/setB_15_PRN_Possessive_sentences_csv.csv", 1, "prn_possessive_sentences");
            readCsv("stimuli_setB/setB_16_PRN_Possessive_csv.csv", 1, "prn_possessive");
            readCsv("stimuli_setB/setB_17_PRN_Personal_csv.csv", 1, "prn_personal");

            readCsv("stimuli_setB/setB_18_Tense_Simple_csv.csv", 2, "tense_simple");
            readCsv("stimuli_setB/setB_19_Tense_Progressive_csv.csv", 2, "tense_progressive");

            readCsv("stimuli_setB/setB_20_Verb_Intransitive_csv.csv", 1, "verb_intransitive");
            readCsv("stimuli_setB/setB_21_Verb_IntransitivePP_csv.csv", 2, "verb_intransitivePP");
            readCsv("stimuli_setB/setB_22_Verb_Transitive_csv.csv", 2, "verb_transitive");
            readCsv("stimuli_setB/setB_23_Verb_Ditransitive_csv.csv", 2, "verb_ditransitive");
            readCsv("stimuli_setB/setB_24_Verb_TransitivePP_csv.csv", 2, "verb_transitivePP");

            readCsv("stimuli_setB/setB_25_Adj_Phrase_csv.csv", 1, "adj_phrase");
            readCsv("stimuli_setB/setB_26_Adj_Sentence_csv.csv", 1, "adj_sentence");
            readCsv("stimuli_setB/setB_27_Adj_Intrans_sent_csv.csv", 2, "adj_intrans_sent");

            saveLexicalItemsToXml("setB_stimuli_lexicalitems_all.xml");
            saveChallengeItemsToXml("setB_stimuli_challengeitems_all.xml");
            saveChallengeItemFeaturesToCsv("setB_stimuli_challengeitemfeatures_all.csv");
            saveChallengeItemFeaturesForcedToCsv("setB_stimuli_challengeitemfeatures_forced_all.csv");
            */

            // set B
            readCsv("stimuli_setB/setB_7_Noun_1syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_1syll_word);
            readCsv("stimuli_setB/setB_7_Noun_1syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_1syll_phrase);
            readCsv("stimuli_setB/setB_8_Noun_2syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_2syll_word);
            readCsv("stimuli_setB/setB_8_Noun_2syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_2syll_phrase);
            readCsv("stimuli_setB/setB_9_Noun_3syll_word_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_3syll_word);
            readCsv("stimuli_setB/setB_9_Noun_3syll_phrase_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_3syll_phrase);

            readCsv("stimuli_setB/setB_10_Noun_attributive_csv.csv", (int)CConstants.g_LinguisticType.Word, CConstants.g_LinguisticCategory.noun_attributive);
            readCsv("stimuli_setB/setB_11_Noun_predicative_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.noun_predicative);
            readCsv("stimuli_setB/setB_12_Noun_Intransitive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.noun_intransitive);

            readCsv("stimuli_setB/setB_1_Noun_IntransitivePPbeg_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_intransitivePPbeg);
            readCsv("stimuli_setB/setB_2_Noun_IntransitivePPend_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_intransitivePPend);
            readCsv("stimuli_setB/setB_3_Noun_transitive_beg_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitive_beg);
            readCsv("stimuli_setB/setB_4_Noun_transitive_end_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitive_end);
            readCsv("stimuli_setB/setB_5_Noun_TransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_transitivePP);
            readCsv("stimuli_setB/setB_6_Noun_Ditransitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.noun_ditransitive);


            readCsv("stimuli_setB/setB_13_Prep_Phrase_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prep_phrase);
            readCsv("stimuli_setB/setB_14_Prep_Sentence_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.prep_sentence);

            readCsv("stimuli_setB/setB_15_PRN_Possessive_sentences_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_possessive_sentences);
            readCsv("stimuli_setB/setB_16_PRN_Possessive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_possessive);
            readCsv("stimuli_setB/setB_17_PRN_Personal_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.prn_personal);

            readCsv("stimuli_setB/setB_18_Tense_Simple_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.tense_simple);
            readCsv("stimuli_setB/setB_19_Tense_Progressive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.tense_progressive);

            readCsv("stimuli_setB/setB_20_Verb_Intransitive_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.verb_intransitive);
            readCsv("stimuli_setB/setB_21_Verb_IntransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_intransitivePP);
            readCsv("stimuli_setB/setB_22_Verb_Transitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_transitive);
            readCsv("stimuli_setB/setB_23_Verb_Ditransitive_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_ditransitive);
            readCsv("stimuli_setB/setB_24_Verb_TransitivePP_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.verb_transitivePP);

            readCsv("stimuli_setB/setB_25_Adj_Phrase_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.adj_phrase);
            readCsv("stimuli_setB/setB_26_Adj_Sentence_csv.csv", (int)CConstants.g_LinguisticType.EasySentence, CConstants.g_LinguisticCategory.adj_sentence);
            readCsv("stimuli_setB/setB_27_Adj_Intrans_sent_csv.csv", (int)CConstants.g_LinguisticType.HardSentence, CConstants.g_LinguisticCategory.adj_intrans_sent);

            saveLexicalItemsToXml("setB_stimuli_lexicalitems_all.xml");
            saveChallengeItemsToXml("setB_stimuli_challengeitems_all.xml");
            saveChallengeItemFeaturesToCsv("setB_stimuli_challengeitemfeatures_all.csv");
            saveChallengeItemFeaturesForcedToCsv("setB_stimuli_challengeitemfeatures_forced_all.csv");



            /*
            readCsv("stimuli/stimuli_noun_word_123syll.csv", 0, "noun_word");
            readCsv("stimuli/stimuli_noun_phrase_12syll.csv", 0, "noun_phrase");
            readCsv("stimuli/stimuli_noun_phrase_atrributive.csv", 1, "noun_phrase_attributive");
            readCsv("stimuli/stimuli_noun_sentence_predicate_adj.csv", 1, "noun_sentence_predicate_adj");
            readCsv("stimuli/stimuli_noun_sentence_intransitivePP_beg.csv", 2, "noun_sentence_intransitivePP_beg");
            readCsv("stimuli/stimuli_noun_sentence_intransitivePP_end.csv", 2, "noun_sentence_intransitivePP_end");

            readCsv("stimuli/stimuli_verb_sentence_transitive.csv", 2, "verb_sentence_transitive");
            readCsv("stimuli/stimuli_verb_sentence_intransitive.csv", 1, "verb_sentence_intransitive");
            readCsv("stimuli/stimuli_verb_sentence_intransitivePP.csv", 2, "verb_sentence_intransitivePP");
            readCsv("stimuli/stimuli_verb_sentence_ditransitive.csv", 2, "verb_sentence_ditransitive");                      

            saveLexicalItemsToXml("stimuli_noun_verb_lexicalitems.xml");
            saveChallengeItemsToXml("stimuli_noun_verb_challengeitems.xml");
            saveChallengeItemFeaturesToCsv("stimuli_noun_verb_challengeitemfeatures.csv");
            //calculateNeighbours("stimuli_noun_verb_neighbours_300_th_0-5_rand.csv");
            */
        }

        //----------------------------------------------------------------------------------------------------
        // readCsv
        //----------------------------------------------------------------------------------------------------
        public void readCsv(string strCsvFile, int intLinguisticType, CConstants.g_LinguisticCategory linguisticCategory)
        {
            //string strWholeFile = System.IO.File.ReadAllText ();
            //string contents = System.IO.File.ReadAllText(@"C:\temp\test.txt");

            string strWholeFile = System.IO.File.ReadAllText(strCsvFile);

            /*
                2,hospital,,Linguistic unit,P type,Image ID,Audio ID,Freq bin,Conc bin,Syllable
                ,,Target,hospital,target,156022646,,8,7,3
                ,,P1,hostel,distant,230648185,,,,
                ,,P2,hosepipe,distant,106051277,, ,,
                ,,P3,x,x,x,,,,
                ,,S1,ambulance,assoc,35015805,,,,
                ,,S2,stethoscope,assoc,173685527,,,,
                ,,Un,x,x,x,,,,
                ,,Un,car,un,9545845848,,,,
                ,,,,,,,,,
            */

            // split into lines
            strWholeFile = strWholeFile.Replace('\n', '\r');
            string[] lines = strWholeFile.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // see how many rows & columns there are
            int intNumRows = lines.Length;
            int intNumCols = lines[0].Split(',').Length;

            int i = 0;
            while (i < intNumRows)
            {
                if ((i % 10) == 0) // each stimulus set has 10 lines
                {
                    CLexicalItem lexicalItem = new CLexicalItem();
                    CChallengeItem challengeItem = new CChallengeItem();
                    CChallengeItemFeatures challengeItemFeatures = new CChallengeItemFeatures();

                    // list of challlengeIdx for this lexicalItem
                    List<int> lsChallengeItemIdx = new List<int>();

                    // list of challlengeFeaturesIdx for this challengeItem
                    List<int> lsChallengeItemFeaturesIdx = new List<int>();

                    // first line, second field = lexical item name - 2,hospital,,Linguistic unit,P type,Image ID,Audio ID,Freq bin,Conc bin,Syllable
                    string[] line_first = lines[i].Split(',');
                    lexicalItem.m_strName = line_first[1];

                    i++; // next line
                    for (int j = 1; j < 9; j++)
                    {
                        string[] line_r = lines[i].Split(',');
                        if (line_r[2] == "Target")
                            line_r[2] = "target";

                        // ,,Target,hospital,target,156022646,,8,7,3
                        if (j == 1)
                        {
                            challengeItem.m_intLexicalItemIdx = findLexicalItemIdx(lexicalItem);
                            challengeItem.m_intFrequency = Convert.ToInt32(line_r[11]);
                            challengeItem.m_intConcreteness = Convert.ToInt32(line_r[12]);
                            if (challengeItem.m_intConcreteness == 8)
                                challengeItem.m_intConcreteness = 7;
                            challengeItem.m_intSyllableNum = Convert.ToInt32(line_r[13]);

                            //challengeItem.m_intId = ++intStimulusNum;
                            challengeItem.m_strName = line_r[3];
                            challengeItem.m_intLinguisticType = intLinguisticType;
                            challengeItem.m_strLinguisticCategoryName = linguisticCategory.ToString();
                            //challengeItem.m_strAudioFile = line_r[6];
                            if (line_r[6] != "") challengeItem.m_lsAudioFile.Add(line_r[6]);
                            if (line_r[7] != "") challengeItem.m_lsAudioFile.Add(line_r[7]);
                            if (line_r[8] != "") challengeItem.m_lsAudioFile.Add(line_r[8]);
                            if (line_r[9] != "") challengeItem.m_lsAudioFile.Add(line_r[9]);
                            if (line_r[10] != "") challengeItem.m_lsAudioFile.Add(line_r[10]);
                            // remove .wav
                            //string[] strWav = line_r[3].Split('.');
                            //trial.m_strTargetAudio = strWav[0];

                            if (line_r[14] == "1")
                                challengeItem.m_intForcedItem = 1;
                            else
                                challengeItem.m_intForcedItem = 0;

                            // Console.WriteLine(challengeItem.m_strName);
                        }

                        // ,,P1,hostel,distant,230648185,,,,
                        if ((line_r[3] == "x") || (line_r[3] == "X") || (line_r[3] == "xx") || (line_r[3] == "XX") || (line_r[3] == "") ||
                             (line_r[4] == "x") || (line_r[4] == "X") || (line_r[5] == "x") || (line_r[5] == "X"))
                        { }
                        else
                        {
                            CPictureChoice picChoice = new CPictureChoice();
                            picChoice.m_strType = line_r[2]; picChoice.m_strType = picChoice.m_strType.ToLower();
                            picChoice.m_strName = line_r[3];
                            picChoice.m_strPType = line_r[4]; picChoice.m_strPType = picChoice.m_strPType.ToLower();
                            picChoice.m_strImageFile = line_r[5];
                            challengeItem.m_lsPictureChoice.Add(picChoice);
                            //Console.WriteLine(picChoice.m_strType + ", " + picChoice.m_strName);
                        }
                        i++;
                    }
                    challengeItem.m_intTargetIdx = 0;
                    m_lsChallengeItem.Add(challengeItem);
                    lsChallengeItemIdx.Add(m_lsChallengeItem.Count - 1);

                    challengeItemFeatures.m_strName = challengeItem.m_strName;
                    challengeItemFeatures.m_intChallengeItemIdx = m_lsChallengeItem.Count - 1;
                    challengeItemFeatures.m_intFrequency = challengeItem.m_intFrequency;
                    challengeItemFeatures.m_intConcreteness = challengeItem.m_intConcreteness;
                    challengeItemFeatures.m_intLinguisticCategory = (int)linguisticCategory;
                    challengeItemFeatures.m_intLinguisticType = intLinguisticType;

                    // compute complexities
                    challengeItemFeatures.m_dComplexity_Frequency = 1.1 - Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intFrequency - 1)) / (8 - 1)) + 0.1, 4);
                    challengeItemFeatures.m_dComplexity_Concreteness = 1.1 - Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intConcreteness - 1)) / (7 - 1)) + 0.1, 4);
                    challengeItemFeatures.m_dComplexity_LinguisticType = Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intLinguisticType - 0)) / (2 - 0)) + 0.1, 4);

                    // compose CChallnegeItemFetures based on no of distractors; ex: ball-2, ball-3, ball-4, ball-5
                    for (int k = 2; k < challengeItem.m_lsPictureChoice.Count; k++)
                    {
                        if (k > 5) break;  // max 5 distractors

                        CChallengeItemFeatures challengeItemFeatures1 = new CChallengeItemFeatures(challengeItemFeatures);
                        challengeItemFeatures1.m_intDistractorNum = k;
                        challengeItemFeatures1.m_dComplexity_DistractorNum = Math.Round((((1 - 0.1) * (challengeItemFeatures1.m_intDistractorNum - 2)) / (5 - 2)) + 0.1, 4);

                        double dTotal = challengeItemFeatures1.m_dComplexity_Frequency + challengeItemFeatures1.m_dComplexity_Concreteness +
                                            challengeItemFeatures1.m_dComplexity_LinguisticType + challengeItemFeatures1.m_dComplexity_DistractorNum;
                        challengeItemFeatures1.m_dComplexity_Overall = Math.Round((dTotal / 4), 4);

                        m_lsChallengeItemFeatures.Add(challengeItemFeatures1);
                        lsChallengeItemFeaturesIdx.Add(m_lsChallengeItemFeatures.Count - 1);

                        // add index to forced_item list
                        if (challengeItem.m_intForcedItem == 1)
                            m_lsChallengeItemFeatures_Forced.Add(m_lsChallengeItemFeatures.Count - 1);
                    }

                    // compose CChallnegeItemFetures based on noise level
                    /*for (int j = 0; j < Enum.GetNames(typeof(CConstants.g_NoiseLevel)).Length; j++)
                    {
                        challengeItemFeatures.m_intNoiseLevel = j;
                        challengeItemFeatures.m_dComplexity_NoiseLevel = Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intNoiseLevel - 0)) / (5 - 0)) + 0.1, 4);

                        // compose CChallnegeItemFetures based on no of distractors; ex: ball-2, ball-3, ball-4, ball-5
                        for (int k = 2; k < challengeItem.m_lsPictureChoice.Count; k++)
                        {
                            CChallengeItemFeatures challengeItemFeatures1 = new CChallengeItemFeatures(challengeItemFeatures);
                            challengeItemFeatures1.m_intDistractorNum = k;
                            challengeItemFeatures1.m_dComplexity_DistractorNum = Math.Round((((1 - 0.1) * (challengeItemFeatures1.m_intDistractorNum - 2)) / (5 - 2)) + 0.1, 4);

                            double dTotal = challengeItemFeatures1.m_dComplexity_Frequency + challengeItemFeatures1.m_dComplexity_Concreteness +
                                                challengeItemFeatures1.m_dComplexity_LinguisticCategory + challengeItemFeatures1.m_dComplexity_NoiseLevel +
                                                challengeItemFeatures1.m_dComplexity_DistractorNum;
                            challengeItemFeatures1.m_dComplexity_Overall = Math.Round((dTotal / 5), 4);

                            m_lsChallengeItemFeatures.Add(challengeItemFeatures1);
                            //lsChallengeItemIdx.Add(m_lsChallengeItem.Count-1);
                        }
                    }*/

                    // update challenge item's m_lsChallengeItemFeatures
                    m_lsChallengeItem[m_lsChallengeItem.Count - 1].updateChallengeItemFeaturesIdx(lsChallengeItemFeaturesIdx);

                    // update lexical item's m_lsChallengeItem
                    m_lsLexicalItem[challengeItem.m_intLexicalItemIdx].updateChallengeItemIdx(lsChallengeItemIdx);

                    i++; // skip the last empty line
                }

            }    // end while

            return;
        }

        //----------------------------------------------------------------------------------------------------
        // readCsv
        //----------------------------------------------------------------------------------------------------
        public void readCsv_old(string strCsvFile, int intLinguisticCategory, string strLinguisticCategoryName)
        {       
            //string strWholeFile = System.IO.File.ReadAllText ();
            //string contents = System.IO.File.ReadAllText(@"C:\temp\test.txt");

/*            string strWholeFile = System.IO.File.ReadAllText(strCsvFile);

            /*
                2,hospital,,Linguistic unit,P type,Image ID,Audio ID,Freq bin,Conc bin,Syllable
                ,,Target,hospital,target,156022646,,8,7,3
                ,,P1,hostel,distant,230648185,,,,
                ,,P2,hosepipe,distant,106051277,, ,,
                ,,P3,x,x,x,,,,
                ,,S1,ambulance,assoc,35015805,,,,
                ,,S2,stethoscope,assoc,173685527,,,,
                ,,Un,x,x,x,,,,
                ,,Un,car,un,9545845848,,,,
                ,,,,,,,,,
            */

            // split into lines
 /*           strWholeFile = strWholeFile.Replace('\n', '\r');
            string[] lines = strWholeFile.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // see how many rows & columns there are
            int intNumRows = lines.Length;
            int intNumCols = lines[0].Split(',').Length;
                        
            int i = 0;
            while (i < intNumRows)
            {
                if ((i % 10) == 0) // each stimulus set has 10 lines
                {
                    CLexicalItem lexicalItem = new CLexicalItem();
                    CChallengeItem challengeItem = new CChallengeItem();
                    CChallengeItemFeatures challengeItemFeatures = new CChallengeItemFeatures();

                    // list of challlengeIdx for this lexicalItem
                    List<int> lsChallengeItemIdx = new List<int>();

                    // list of challlengeFeaturesIdx for this challengeItem
                    List<int> lsChallengeItemFeaturesIdx = new List<int>();

                    // first line, second field = lexical item name - 2,hospital,,Linguistic unit,P type,Image ID,Audio ID,Freq bin,Conc bin,Syllable
                    string[] line_first = lines[i].Split(',');
                    lexicalItem.m_strName = line_first[1];

                    i++; // next line
                    for (int j = 1; j < 9; j++)
                    {
                        string[] line_r = lines[i].Split(',');
                        if (line_r[2] == "Target")
                            line_r[2] = "target";

                        // ,,Target,hospital,target,156022646,,8,7,3
                        if (j == 1)
                        {                            
                            challengeItem.m_intLexicalItemIdx = findLexicalItemIdx(lexicalItem);
                            challengeItem.m_intFrequency = Convert.ToInt32(line_r[11]);
                            challengeItem.m_intConcreteness = Convert.ToInt32(line_r[12]);
                            if (challengeItem.m_intConcreteness == 8)
                                challengeItem.m_intConcreteness = 7;
                            challengeItem.m_intSyllableNum = Convert.ToInt32(line_r[13]);

                            //challengeItem.m_intId = ++intStimulusNum;
                            challengeItem.m_strName = line_r[3];
                            challengeItem.m_intLinguisticType = intLinguisticCategory;
                            challengeItem.m_strLinguisticCategoryName = strLinguisticCategoryName;
                            //challengeItem.m_strAudioFile = line_r[6];
                            if (line_r[6] != "") challengeItem.m_lsAudioFile.Add(line_r[6]);
                            if (line_r[7] != "") challengeItem.m_lsAudioFile.Add(line_r[7]);
                            if (line_r[8] != "") challengeItem.m_lsAudioFile.Add(line_r[8]);
                            if (line_r[9] != "") challengeItem.m_lsAudioFile.Add(line_r[9]);
                            if (line_r[10] != "") challengeItem.m_lsAudioFile.Add(line_r[10]);
                            // remove .wav
                            //string[] strWav = line_r[3].Split('.');
                            //trial.m_strTargetAudio = strWav[0];

                            if (line_r[14] == "")
                                challengeItem.m_intForcedItem = 0;
                            else
                                challengeItem.m_intForcedItem = 1;

                            // Console.WriteLine(challengeItem.m_strName);
                        }

                        // ,,P1,hostel,distant,230648185,,,,
                        if ( (line_r[3] == "x") || (line_r[3] == "X") || (line_r[3] == "xx") || (line_r[3] == "XX") || (line_r[3] == "") ||
                             (line_r[4] == "x") || (line_r[4] == "X") || (line_r[5] == "x") || (line_r[5] == "X")  )
                        { }
                        else
                        {
                            CPictureChoice picChoice = new CPictureChoice();
                            picChoice.m_strType = line_r[2]; picChoice.m_strType = picChoice.m_strType.ToLower();
                            picChoice.m_strName = line_r[3];
                            picChoice.m_strPType = line_r[4]; picChoice.m_strPType = picChoice.m_strPType.ToLower();
                            picChoice.m_strImageFile = line_r[5];
                            challengeItem.m_lsPictureChoice.Add(picChoice);
                            //Console.WriteLine(picChoice.m_strType + ", " + picChoice.m_strName);
                        }
                        i++;
                    }
                    challengeItem.m_intTargetIdx = 0;
                    m_lsChallengeItem.Add(challengeItem);
                    lsChallengeItemIdx.Add(m_lsChallengeItem.Count - 1);

                    challengeItemFeatures.m_strName = challengeItem.m_strName;
                    challengeItemFeatures.m_intChallengeItemIdx = m_lsChallengeItem.Count - 1;
                    challengeItemFeatures.m_intFrequency = challengeItem.m_intFrequency;
                    challengeItemFeatures.m_intConcreteness = challengeItem.m_intConcreteness;
                    challengeItemFeatures.m_intLinguisticCategory = challengeItem.m_intLinguisticCategory;

                    // compute complexities
                    challengeItemFeatures.m_dComplexity_Frequency = 1.1 - Math.Round ( ( ((1 - 0.1) * (challengeItemFeatures.m_intFrequency - 1)) / (8 - 1) ) + 0.1, 4);
                    challengeItemFeatures.m_dComplexity_Concreteness = 1.1 - Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intConcreteness - 1)) / (7 - 1)) + 0.1, 4);
                    challengeItemFeatures.m_dComplexity_LinguisticType = Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intLinguisticCategory - 0)) / (2 - 0)) + 0.1, 4);

                    // compose CChallnegeItemFetures based on no of distractors; ex: ball-2, ball-3, ball-4, ball-5
                    for (int k = 2; k < challengeItem.m_lsPictureChoice.Count; k++)
                    {
                        if (k > 5) break;  // max 5 distractors

                        CChallengeItemFeatures challengeItemFeatures1 = new CChallengeItemFeatures(challengeItemFeatures);
                        challengeItemFeatures1.m_intDistractorNum = k;
                        challengeItemFeatures1.m_dComplexity_DistractorNum = Math.Round((((1 - 0.1) * (challengeItemFeatures1.m_intDistractorNum - 2)) / (5 - 2)) + 0.1, 4);

                        double dTotal = challengeItemFeatures1.m_dComplexity_Frequency + challengeItemFeatures1.m_dComplexity_Concreteness +
                                            challengeItemFeatures1.m_dComplexity_LinguisticCategory + challengeItemFeatures1.m_dComplexity_DistractorNum;
                        challengeItemFeatures1.m_dComplexity_Overall = Math.Round((dTotal / 4), 4);

                        m_lsChallengeItemFeatures.Add(challengeItemFeatures1);
                        lsChallengeItemFeaturesIdx.Add(m_lsChallengeItemFeatures.Count-1);

                        // add index to forced_item list
                        if (challengeItem.m_intForcedItem == 1)
                            m_lsChallengeItemFeatures_Forced.Add(m_lsChallengeItemFeatures.Count - 1);
                    }

                    // compose CChallnegeItemFetures based on noise level
                    /*for (int j = 0; j < Enum.GetNames(typeof(CConstants.g_NoiseLevel)).Length; j++)
                    {
                        challengeItemFeatures.m_intNoiseLevel = j;
                        challengeItemFeatures.m_dComplexity_NoiseLevel = Math.Round((((1 - 0.1) * (challengeItemFeatures.m_intNoiseLevel - 0)) / (5 - 0)) + 0.1, 4);

                        // compose CChallnegeItemFetures based on no of distractors; ex: ball-2, ball-3, ball-4, ball-5
                        for (int k = 2; k < challengeItem.m_lsPictureChoice.Count; k++)
                        {
                            CChallengeItemFeatures challengeItemFeatures1 = new CChallengeItemFeatures(challengeItemFeatures);
                            challengeItemFeatures1.m_intDistractorNum = k;
                            challengeItemFeatures1.m_dComplexity_DistractorNum = Math.Round((((1 - 0.1) * (challengeItemFeatures1.m_intDistractorNum - 2)) / (5 - 2)) + 0.1, 4);

                            double dTotal = challengeItemFeatures1.m_dComplexity_Frequency + challengeItemFeatures1.m_dComplexity_Concreteness +
                                                challengeItemFeatures1.m_dComplexity_LinguisticCategory + challengeItemFeatures1.m_dComplexity_NoiseLevel +
                                                challengeItemFeatures1.m_dComplexity_DistractorNum;
                            challengeItemFeatures1.m_dComplexity_Overall = Math.Round((dTotal / 5), 4);

                            m_lsChallengeItemFeatures.Add(challengeItemFeatures1);
                            //lsChallengeItemIdx.Add(m_lsChallengeItem.Count-1);
                        }
                    }*/

                    // update challenge item's m_lsChallengeItemFeatures
 /*                   m_lsChallengeItem[m_lsChallengeItem.Count - 1].updateChallengeItemFeaturesIdx(lsChallengeItemFeaturesIdx);

                    // update lexical item's m_lsChallengeItem
                    m_lsLexicalItem[challengeItem.m_intLexicalItemIdx].updateChallengeItemIdx(lsChallengeItemIdx);
                    
                    i++; // skip the last empty line
                }

            }    // end while

            return ;
 */       }

        //----------------------------------------------------------------------------------------------------
        // findLexicalItemIdx
        //----------------------------------------------------------------------------------------------------
        public int findLexicalItemIdx(CLexicalItem lexicalItem)
        {
            int intIdx = -1;
            intIdx = m_lsLexicalItem.FindIndex(x => x.m_strName.Equals(lexicalItem.m_strName));  //m_lsLexicalItem.FindIndex(x => x.m_strName == "1444");
            if (intIdx < 0)
            {
                m_lsLexicalItem.Add(new CLexicalItem(lexicalItem));
                intIdx = m_lsLexicalItem.Count - 1;
            }

            return intIdx;
        }

        //----------------------------------------------------------------------------------------------------
        // saveLexicalItemsToXml
        //----------------------------------------------------------------------------------------------------
        public void saveLexicalItemsToXml(string strXmlFile)
        {        
            // save lsTrial to xml 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' encoding='utf-8'?>" +
                "<root>" +
                "</root>");

            // Save the document to a file. White space is preserved (no white space).
            //string strFile = "stimuli_noun_3syllables.xml";

            /*
			<item idx="0">
			  	<name>ball</name>
			  	<frequency>8</frequency>
			  	<concreteness>7</concreteness>
			  	<syllableNum>4</syllableNum>
			  	<challengeItems>
                    <idx> 0 </idx>
                    <idx> 3 </idx>
                    <idx> 10 </idx>
			    </challengeItems>                
			</item> 
			*/

            for (int i = 0; i < m_lsLexicalItem.Count; i++)
            {
                XmlElement xmlNode = doc.CreateElement("item");
                XmlAttribute attr = doc.CreateAttribute("idx");
                attr.Value = i.ToString();
                xmlNode.SetAttributeNode(attr);

                XmlElement xmlChild2 = doc.CreateElement("name");
                xmlChild2.InnerText = m_lsLexicalItem[i].m_strName;
                xmlNode.AppendChild(xmlChild2);

                /*xmlChild2 = doc.CreateElement("freq");
                xmlChild2.InnerText = m_lsLexicalItem[i].m_intFrequency.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("conc");
                xmlChild2.InnerText = m_lsLexicalItem[i].m_intConcreteness.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("syll");
                xmlChild2.InnerText = m_lsLexicalItem[i].m_intSyllableNum.ToString();
                xmlNode.AppendChild(xmlChild2);*/

                // add challenge item idx
                //xmlChild2 = doc.CreateElement("challengeItems");
                for (var j = 0; j < m_lsLexicalItem[i].m_lsChallengeItemIdx.Count; j++)
                {
                    XmlElement xmlChallengeItem = doc.CreateElement("ciIdx");
                    xmlChallengeItem.InnerText = m_lsLexicalItem[i].m_lsChallengeItemIdx[j].ToString();                                
                    xmlNode.AppendChild(xmlChallengeItem);
                }
                //xmlNode.AppendChild(xmlChild2);

                doc.DocumentElement.AppendChild(xmlNode);
            }

            //doc.PreserveWhitespace = true;
            doc.Save(strXmlFile);
        }

        //----------------------------------------------------------------------------------------------------
        // saveChallengeItemsToXml
        //----------------------------------------------------------------------------------------------------
        public void saveChallengeItemsToXml(string strXmlFile)
        {
            // save m_lsChallengeItem to xml 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' encoding='utf-8'?>" +
                "<root>" +
                "</root>");

            // Save the document to a file. White space is preserved (no white space).
            //string strFile = "stimuli_noun_3syllables.xml";

            /*
			<item idx="0">
			  	<name>ball</name>
                <lexicalItemIdx>9</lexicalItemIdx>	
			  	<linguisticCategory>0</linguisticCategory>
                <linguisticCategoryName>noun</linguisticCategoryName>
                <distractorNum>3</distractorNum>
                <noiseLevel>0</noiseLevel>			  	
			  	<audioFile>LI_1syll_Noun_f1_001</audioFile>
			  	<targetIdx>0</targetIdx>
			    <pictureChoice idx="0" name="ball" type="target" imageFile="66600742" />
			    <pictureChoice idx="1" name="wall" type="P1" imageFile="66600742" />
			    <pictureChoice idx="2" name="bell" type="P2" imageFile="66600742" />
			    <pictureChoice idx="3" name="bull" type="P3" imageFile="66600742" />
			    <pictureChoice idx="4" name="net" type="S1" imageFile="66600742" />
			    <pictureChoice idx="5" name="bat" type="S2" imageFile="66600742" />
			</item> 
			*/

            for (int i = 0; i < m_lsChallengeItem.Count; i++)
            {
                XmlElement xmlNode = doc.CreateElement("item");
                XmlAttribute attr = doc.CreateAttribute("idx");
                attr.Value = i.ToString();
                xmlNode.SetAttributeNode(attr);

                XmlElement xmlChild2 = doc.CreateElement("name");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_strName;
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("freq");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intFrequency.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("conc");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intConcreteness.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("syll");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intSyllableNum.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("li");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intLexicalItemIdx.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("lt");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intLinguisticType.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("lcn");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_strLinguisticCategoryName;
                xmlNode.AppendChild(xmlChild2);

                /*xmlChild2 = doc.CreateElement("distractorNum");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intDistractorNum.ToString();
                xmlNode.AppendChild(xmlChild2);

                xmlChild2 = doc.CreateElement("noiseLevel");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intNoiseLevel.ToString();
                xmlNode.AppendChild(xmlChild2);*/

                for (var j = 0; j < m_lsChallengeItem[i].m_lsAudioFile.Count; j++)
                {
                    xmlChild2 = doc.CreateElement("aud");
                    xmlChild2.InnerText = m_lsChallengeItem[i].m_lsAudioFile[j];
                    xmlNode.AppendChild(xmlChild2);
                }

                xmlChild2 = doc.CreateElement("tgt");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intTargetIdx.ToString();
                xmlNode.AppendChild(xmlChild2);

                // add picture choices
                for (var j = 0; j < m_lsChallengeItem[i].m_lsPictureChoice.Count; j++)
                {
                    XmlElement xmlPicChoice = doc.CreateElement("picC");
                    XmlAttribute attr1 = doc.CreateAttribute("idx");
                    attr1.Value = j.ToString();
                    xmlPicChoice.SetAttributeNode(attr1);

                    attr1 = doc.CreateAttribute("n");
                    attr1.Value = m_lsChallengeItem[i].m_lsPictureChoice[j].m_strName;
                    xmlPicChoice.SetAttributeNode(attr1);

                    attr1 = doc.CreateAttribute("t");
                    attr1.Value = m_lsChallengeItem[i].m_lsPictureChoice[j].m_strType;
                    xmlPicChoice.SetAttributeNode(attr1);

                    attr1 = doc.CreateAttribute("pt");
                    attr1.Value = m_lsChallengeItem[i].m_lsPictureChoice[j].m_strPType;
                    xmlPicChoice.SetAttributeNode(attr1);

                    attr1 = doc.CreateAttribute("img");
                    attr1.Value = m_lsChallengeItem[i].m_lsPictureChoice[j].m_strImageFile;
                    xmlPicChoice.SetAttributeNode(attr1);

                    xmlNode.AppendChild(xmlPicChoice);
                }

                xmlChild2 = doc.CreateElement("forced");
                xmlChild2.InnerText = m_lsChallengeItem[i].m_intForcedItem.ToString();
                xmlNode.AppendChild(xmlChild2);

                // add challenge item features idx
                for (var j = 0; j < m_lsChallengeItem[i].m_lsChallengeItemFeaturesIdx.Count; j++)
                {
                    XmlElement xmlFeatrues = doc.CreateElement("cifIdx");
                    xmlFeatrues.InnerText = m_lsChallengeItem[i].m_lsChallengeItemFeaturesIdx[j].ToString();
                    xmlNode.AppendChild(xmlFeatrues);
                }

                doc.DocumentElement.AppendChild(xmlNode);
            }

            //doc.PreserveWhitespace = true;
            doc.Save(strXmlFile);

        }

        //----------------------------------------------------------------------------------------------------
        // saveChallengeItemFeaturesToCsv
        //----------------------------------------------------------------------------------------------------
        public void saveChallengeItemFeaturesToCsv(string strCsvFile)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(strCsvFile))
            {
                for (var i = 0; i < m_lsChallengeItemFeatures.Count; i++)
                {
                    CChallengeItemFeatures challengeItemFeatures = m_lsChallengeItemFeatures[i];

                    string strRow = "";
                    strRow = strRow + i + "," + challengeItemFeatures.m_intChallengeItemIdx + "," + /*challengeItemFeatures.m_strName + "," + */
                                challengeItemFeatures.m_intFrequency + "," +
                                challengeItemFeatures.m_intConcreteness + "," + challengeItemFeatures.m_intDistractorNum + "," +
                                challengeItemFeatures.m_intLinguisticCategory + "," + challengeItemFeatures.m_intLinguisticType + "," + /*challengeItemFeatures.m_intNoiseLevel + "," + */
                                challengeItemFeatures.m_dComplexity_Frequency + "," +
                                challengeItemFeatures.m_dComplexity_Concreteness + "," + challengeItemFeatures.m_dComplexity_DistractorNum + "," +
                                challengeItemFeatures.m_dComplexity_LinguisticType + "," + /*challengeItemFeatures.m_dComplexity_NoiseLevel + "," +*/
                                challengeItemFeatures.m_dComplexity_Overall + ",";

                    // write to file
                    sw.WriteLine(strRow);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // saveChallengeItemFeaturesForcedToCsv
        //----------------------------------------------------------------------------------------------------
        public void saveChallengeItemFeaturesForcedToCsv(string strCsvFile)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(strCsvFile))
            {
                for (var i = 0; i < m_lsChallengeItemFeatures_Forced.Count; i++)
                {
                    string strRow = m_lsChallengeItemFeatures_Forced[i] + ",";
                    // write to file
                    sw.WriteLine(strRow);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // loadLexicalItems (xml)
        //----------------------------------------------------------------------------------------------------
        public void loadLexicalItems()
        {
            // if xml has already been loaded, then return
            if (m_lsLexicalItem.Count > 0) return;

            m_lsLexicalItem.Clear();

            // check if file exists
            string strXmlFile = m_strFile_LexicalItem_Xml; // "stimuli_noun_1syllables_lexicalitems.xml"; 
            if (!System.IO.File.Exists(strXmlFile))
                return;

            XElement root = XElement.Load(strXmlFile);
            int intIdx = 0;
            m_lsLexicalItem = (
                from el in root.Elements("item")
                select new CLexicalItem
                {
                    m_intId = intIdx++,  /*(int)el.Attribute("idx"),*/
                    m_strName = (string)el.Element("name"),                    
                    m_lsChallengeItemIdx = (
                        from el2 in el.Elements("ciIdx")
                        select ((int)el2)
                    ).ToList(),
                }
            ).ToList();

            /*for (int i = 0; i < m_lsLexicalItem.Count; i++)
            {
                Console.WriteLine(m_lsLexicalItem[i].m_strName);
                string str = "";
                for (int j = 0; j < m_lsLexicalItem[i].m_lsChallengeItemIdx.Count; j++)
                    str = str + m_lsLexicalItem[i].m_lsChallengeItemIdx[j] + ", ";
                Console.WriteLine(str);
            }*/
        }

        //----------------------------------------------------------------------------------------------------
        // loadChallengeItems (xml)
        //----------------------------------------------------------------------------------------------------
        public void loadChallengeItems()
        {
            // if xml has already been loaded, then return
            if (m_lsChallengeItem.Count > 0) return;

            m_lsChallengeItem.Clear();

            // check if file exists
            string strXmlFile = m_strFile_ChallengeItem_Xml; // "stimuli_noun_1syllables_challengeitems.xml";
            if (!System.IO.File.Exists(strXmlFile))
                return;

            XElement root = XElement.Load(strXmlFile);
            int intIdx = 0;
            m_lsChallengeItem = (
                from el in root.Elements("item")
                select new CChallengeItem
                {
                    m_intId = intIdx++,  /*(int)el.Attribute("idx"),*/
                    m_strName = (string)el.Element("name"),
                    m_intFrequency = (int)el.Element("freq"),
                    m_intConcreteness = (int)el.Element("conc"),
                    m_intSyllableNum = (int)el.Element("syll"),
                    m_intLexicalItemIdx = (int)el.Element("li"),
                    m_intLinguisticType = (int)el.Element("lt"),
                    m_strLinguisticCategoryName = (string)el.Element("lcn"),
                    /*m_strAudioFile = (string)el.Element("audioFile"),*/
                    m_lsAudioFile = (
                        from el2 in el.Elements("aud")
                        select ((string)el2)
                    ).ToList(),
                    m_intTargetIdx = (int)el.Element("tgt"),
                    m_lsPictureChoice = (
                        from el2 in el.Elements("picC")
                        select new CPictureChoice
                        {
                            m_strName = (string)el2.Attribute("n"),
                            m_strImageFile = (string)el2.Attribute("img"),
                            m_strType = (string)el2.Attribute("t"),
                        }
                    ).ToList(),
                    m_lsChallengeItemFeaturesIdx = (
                        from el2 in el.Elements("cifIdx")
                        select ((int)el2)
                    ).ToList(),
                }
            ).ToList();

        }

        //----------------------------------------------------------------------------------------------------
        // loadChallengeItemFeatures
        //----------------------------------------------------------------------------------------------------
        private void loadChallengeItemFeatures()
        {          
            string strWholeFile = System.IO.File.ReadAllText(m_strFile_ChallengeItemFeature_Csv); 

            // split into lines
            strWholeFile = strWholeFile.Replace('\n', '\r');
            string[] lines = strWholeFile.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // see how many rows & columns there are
            int intNumRows = lines.Length;
            //int intNumCols = lines[0].Split(',').Length;

            int i = 0;
            while (i < intNumRows)
            {               
                CChallengeItemFeatures features = new CChallengeItemFeatures();

                string[] line_r = lines[i].Split(',');
                int intNumCols = line_r.Length;

                // first col = idx
                for (int j = 1; j < intNumCols; j++)
                {
                    if (j == 1) features.m_intChallengeItemIdx = Convert.ToInt32(line_r[j]);
                    if (j == 2) features.m_intFrequency = Convert.ToInt32(line_r[j]);
                    if (j == 3) features.m_intConcreteness = Convert.ToInt32(line_r[j]);
                    if (j == 4) features.m_intDistractorNum = Convert.ToInt32(line_r[j]);
                    if (j == 5) features.m_intLinguisticCategory = Convert.ToInt32(line_r[j]);
                    if (j == 6) features.m_intLinguisticType = Convert.ToInt32(line_r[j]);                    
                    if (j == 7) features.m_dComplexity_Frequency = Math.Round(Convert.ToDouble(line_r[j]), 4);
                    if (j == 8) features.m_dComplexity_Concreteness = Math.Round(Convert.ToDouble(line_r[j]), 4);
                    if (j == 9) features.m_dComplexity_DistractorNum = Math.Round(Convert.ToDouble(line_r[j]), 4);
                    if (j == 10) features.m_dComplexity_LinguisticType = Math.Round(Convert.ToDouble(line_r[j]), 4);
                    if (j == 11) features.m_dComplexity_Overall = Math.Round(Convert.ToDouble(line_r[j]), 4);
                }
                m_lsChallengeItemFeatures.Add(features);

                i++; // next line
            }    // end while

            /*{
                string str = "";
                str = str + m_lsChallengeItemFeatures[0].m_dComplexity_Frequency + ", " +
                        m_lsChallengeItemFeatures[0].m_dComplexity_Concreteness + ", " +
                        m_lsChallengeItemFeatures[0].m_dComplexity_DistractorNum + ", " +
                        m_lsChallengeItemFeatures[0].m_dComplexity_LinguisticCategory + ", " +
                        m_lsChallengeItemFeatures[0].m_dComplexity_NoiseLevel + ", ";
                Console.WriteLine(str);
            }*/

        }

        //----------------------------------------------------------------------------------------------------
        // calculateNeighbours & save to csv - use cosine similarity
        //----------------------------------------------------------------------------------------------------
        public void calculateNeighbours()
        {
            //loadLexicalItems();
            loadChallengeItems();
            loadChallengeItemFeatures();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(m_strFile_ChallengeItemFeature_Neighbours_Csv))
            {
                for (var i = 0; i < m_lsChallengeItemFeatures.Count; i++)
                {
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[i].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;
                    //Console.WriteLine("\n" + m_lsChallengeItem[m_lsChallengeItemFeatures[i].m_intChallengeItemIdx].m_strName);

                    CVector_ChallengeItemFeaturesNeighbours vector_Neighbours = new CVector_ChallengeItemFeaturesNeighbours();

                    string strRow = "";
                    strRow = strRow + i + ","; // + challengeItem.m_strName + ",";

                    // shuffle m_lsChallengeItemFeatures in m_lsTrial using Knuth shuffle algorithm :: courtesy of Wikipedia 
                    List<int> lsChallengeItemFeaturesIdx = new List<int>();
                    for (var k = 0; k < m_lsChallengeItemFeatures.Count; k++)
                        lsChallengeItemFeaturesIdx.Add(k);
                    Random rnd = new Random();
                    for (int t = 0; t < lsChallengeItemFeaturesIdx.Count; t++)
                    {
                        int tmp = lsChallengeItemFeaturesIdx[t];
                        int r = (rnd.Next(t, lsChallengeItemFeaturesIdx.Count));
                        lsChallengeItemFeaturesIdx[t] = lsChallengeItemFeaturesIdx[r];
                        lsChallengeItemFeaturesIdx[r] = tmp;
                    }

                    int intCtr = 0;                    

                    intCtr = 0;
                    for (var j = 0; j < lsChallengeItemFeaturesIdx.Count; j++)
                    {
                        //if (intCtr >= 50) break;

                        if (i != lsChallengeItemFeaturesIdx[j])   //if (i != j)
                        {
                            CChallengeItemFeatures_Neighbour neighbour = new CChallengeItemFeatures_Neighbour();
                            neighbour.m_intChallengeItemFeaturesIdx = lsChallengeItemFeaturesIdx[j];
                            neighbour.m_dSimilarity = calculateFeatureSimilarity_CosineSim(m_lsChallengeItemFeatures[i], m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx]); 

                            int intNeighbour_ChallengeItemIdx = m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                            int intNeighbour_LexicalItemIdx = m_lsChallengeItem[intNeighbour_ChallengeItemIdx].m_intLexicalItemIdx;

                            // add neighbour if the neighbour has the same lexical item or has a similarity value higher than the threshold value 0.7
                            bool bAdd = false;
                            /*if (intLexicalItemIdx == intNeighbour_LexicalItemIdx)
                                bAdd = true;
                            else*/ if (neighbour.m_dSimilarity > 0.8)
                            {
                                if (intCtr < 30)
                                    bAdd = true;
                                intCtr++;
                            }

                            if (bAdd)
                            {
                                vector_Neighbours.m_lsChallengeItemFeatures_Neighbour.Add(neighbour);

                                // write to file
                                strRow = strRow + neighbour.m_intChallengeItemFeaturesIdx + "," + neighbour.m_dSimilarity + ",";                                
                            }                                                
                        }
                    }

                    m_lsVector_Neighbours.Add(vector_Neighbours);
                    Console.WriteLine("\n" + i + " - neighbour num = " + vector_Neighbours.m_lsChallengeItemFeatures_Neighbour.Count);

                    // write to file
                    sw.WriteLine(strRow);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // calculateNeighbours & save to csv
        //----------------------------------------------------------------------------------------------------
        public void calculateNeighbours_Euclidean()
        {
            //loadLexicalItems();
            loadChallengeItems();
            loadChallengeItemFeatures();

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(m_strFile_ChallengeItemFeature_Neighbours_Csv))
            {
                for (var i = 0; i < m_lsChallengeItemFeatures.Count; i++)
                {
                    int intChallengeItemIdx = m_lsChallengeItemFeatures[i].m_intChallengeItemIdx;
                    int intLexicalItemIdx = m_lsChallengeItem[intChallengeItemIdx].m_intLexicalItemIdx;
                    //Console.WriteLine("\n" + m_lsChallengeItem[m_lsChallengeItemFeatures[i].m_intChallengeItemIdx].m_strName);
                                    
                    CVector_ChallengeItemFeaturesNeighbours vector_Neighbours = new CVector_ChallengeItemFeaturesNeighbours();                                       

                    string strRow = "";
                    strRow = strRow + i + ","; // + challengeItem.m_strName + ",";

                    // shuffle m_lsChallengeItemFeatures in m_lsTrial using Knuth shuffle algorithm :: courtesy of Wikipedia 
                    List<int> lsChallengeItemFeaturesIdx = new List<int>();
                    for (var k = 0; k < m_lsChallengeItemFeatures.Count; k++)
                        lsChallengeItemFeaturesIdx.Add(k);
                    Random rnd = new Random();
                    for (int t = 0; t < lsChallengeItemFeaturesIdx.Count; t++)
                    {
                        int tmp = lsChallengeItemFeaturesIdx[t];
                        int r = (rnd.Next(t, lsChallengeItemFeaturesIdx.Count));
                        lsChallengeItemFeaturesIdx[t] = lsChallengeItemFeaturesIdx[r];
                        lsChallengeItemFeaturesIdx[r] = tmp;
                    }

                    int intCtr = 0;

                    // calculate top k similarity value
                    /*List<double> lsTop10SimilarityValue = new List<double>();
                    for (var j = 0; j < lsChallengeItemFeaturesIdx.Count; j++)  
                    {
                        //if (intCtr >= 50) break;

                        if (i != lsChallengeItemFeaturesIdx[j])   //if (i != j)
                        {
                            /*List<double> lsFeatures1 = new List<double>();
                            List<double> lsFeatures2 = new List<double>();
                            lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_Frequency);
                            lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_Concreteness);
                            lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_DistractorNum);
                            lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_LinguisticCategory);
                            //lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_NoiseLevel);

                            lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_Frequency);
                            lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_Concreteness);
                            lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_DistractorNum);
                            lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_LinguisticCategory);
                            //lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_NoiseLevel);*/

                    /*     CChallengeItemFeatures_Neighbour neighbour = new CChallengeItemFeatures_Neighbour();
                         neighbour.m_intChallengeItemFeaturesIdx = lsChallengeItemFeaturesIdx[j];
                         neighbour.m_dSimilarity = calculateFeatureSimilarity(m_lsChallengeItemFeatures[i], m_lsChallengeItemFeatures[j]);  //Math.Round(CEuclideanDistance.EuclideanSimilarity(lsFeatures1, lsFeatures2), 4);
                         Console.WriteLine(neighbour.m_dSimilarity);

                         if (lsTop10SimilarityValue.Count < 5)
                         {
                             if (lsTop10SimilarityValue.FindIndex(a => a == neighbour.m_dSimilarity) < 0)
                                 lsTop10SimilarityValue.Add(neighbour.m_dSimilarity);
                             lsTop10SimilarityValue = lsTop10SimilarityValue.OrderByDescending(o => o).ToList();
                         }
                         else
                         {
                             bool bDeleteLast = false;
                             if (lsTop10SimilarityValue.FindIndex(a => a == neighbour.m_dSimilarity) < 0)
                             {
                                 for (var k = 0; k < lsTop10SimilarityValue.Count; k++)
                                 {
                                     if (neighbour.m_dSimilarity > lsTop10SimilarityValue[k])
                                     {
                                         bDeleteLast = true;
                                         break;
                                     }
                                 }
                             }
                             if (bDeleteLast)
                             {
                                 lsTop10SimilarityValue[lsTop10SimilarityValue.Count - 1] = neighbour.m_dSimilarity;
                                 lsTop10SimilarityValue = lsTop10SimilarityValue.OrderByDescending(o => o).ToList();
                             }
                         }

                         // print to console lsTop10SimilarityValue
                         string str = "";
                         for (var k = 0; k < lsTop10SimilarityValue.Count; k++)
                             str = str + lsTop10SimilarityValue[k] + ", ";
                         Console.WriteLine(str);                           

                         //intCtr++;
                         //if (intCtr >= 50) break;                            
                     }
                 }*/

                    intCtr = 0;
                    for (var j = 0; j < lsChallengeItemFeaturesIdx.Count; j++)
                    {
                        //if (intCtr >= 50) break;

                        if (i != lsChallengeItemFeaturesIdx[j])   //if (i != j)
                        {
                            CChallengeItemFeatures_Neighbour neighbour = new CChallengeItemFeatures_Neighbour();
                            neighbour.m_intChallengeItemFeaturesIdx = lsChallengeItemFeaturesIdx[j];
                            neighbour.m_dSimilarity = calculateFeatureSimilarity(m_lsChallengeItemFeatures[i], m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx]); //Math.Round(CEuclideanDistance.EuclideanSimilarity(lsFeatures1, lsFeatures2), 4);

                            int intNeighbour_ChallengeItemIdx = m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx;
                            int intNeighbour_LexicalItemIdx = m_lsChallengeItem[intNeighbour_ChallengeItemIdx].m_intLexicalItemIdx;

                            // add neighbour if the neighbour has the same lexical item or has a similarity value higher than the threshold value 0.7
                            bool bAdd = false;
                            if (intLexicalItemIdx == intNeighbour_LexicalItemIdx)
                                bAdd = true;
                            else if (neighbour.m_dSimilarity > 0.8)
                            {
                                if (intCtr < 20)
                                    bAdd = true;
                                intCtr++;
                            }

                            if (bAdd)
                            {
                                vector_Neighbours.m_lsChallengeItemFeatures_Neighbour.Add(neighbour);

                                // write to file
                                strRow = strRow + neighbour.m_intChallengeItemFeaturesIdx + "," + neighbour.m_dSimilarity + ",";

                                //intCtr++;
                                //Console.Write(m_lsChallengeItem[m_lsChallengeItemFeatures[neighbour.m_intChallengeItemFeaturesIdx].m_intChallengeItemIdx].m_strName + " | ");
                            }

                            // is this similarity value among the top k?
                            /*if (lsTop10SimilarityValue.FindIndex(a => a == neighbour.m_dSimilarity) >= 0)
                            {
                                vector_Neighbours.m_lsChallengeItemFeatures_Neighbour.Add(neighbour);

                                // write to file
                                strRow = strRow + neighbour.m_intChallengeItemFeaturesIdx + "," +
                                            neighbour.m_dSimilarity + ",";

                                intCtr++;
                            }*/

                            //if (intCtr >= 50) break;                            
                        }
                    }

                    m_lsVector_Neighbours.Add(vector_Neighbours);
                    Console.WriteLine("\n" + i + " - neighbour num = " + vector_Neighbours.m_lsChallengeItemFeatures_Neighbour.Count);

                    // write to file
                    sw.WriteLine(strRow);
                }               
            }
        }

        //----------------------------------------------------------------------------------------------------
        // calculateNeighbours & save to csv
        //----------------------------------------------------------------------------------------------------
        public double calculateFeatureSimilarity(CChallengeItemFeatures features1, CChallengeItemFeatures features2)
        {
            double dSimilarity = 0;

            List<double> lsFeatures1 = new List<double>();
            List<double> lsFeatures2 = new List<double>();
            lsFeatures1.Add(features1.m_dComplexity_Frequency);
            lsFeatures1.Add(features1.m_dComplexity_Concreteness);
            lsFeatures1.Add(features1.m_dComplexity_DistractorNum);
            lsFeatures1.Add(features1.m_dComplexity_LinguisticType);
            //lsFeatures1.Add(m_lsChallengeItemFeatures[i].m_dComplexity_NoiseLevel);

            lsFeatures2.Add(features2.m_dComplexity_Frequency);
            lsFeatures2.Add(features2.m_dComplexity_Concreteness);
            lsFeatures2.Add(features2.m_dComplexity_DistractorNum);
            lsFeatures2.Add(features2.m_dComplexity_LinguisticType);
            //lsFeatures2.Add(m_lsChallengeItemFeatures[j].m_dComplexity_NoiseLevel);

            dSimilarity = Math.Round(CEuclideanDistance.EuclideanSimilarity(lsFeatures1, lsFeatures2), 4);            

            return dSimilarity;
        }

        //----------------------------------------------------------------------------------------------------
        // calculateNeighbours & save to csv
        //----------------------------------------------------------------------------------------------------
        public double calculateFeatureSimilarity_CosineSim(CChallengeItemFeatures features1, CChallengeItemFeatures features2)
        {
            double dSimilarity = 0;

            List<int> lsFeatures1 = new List<int>();
            List<int> lsFeatures2 = new List<int>();
            lsFeatures1.Add(features1.m_intFrequency);
            lsFeatures1.Add(features1.m_intConcreteness);
            lsFeatures1.Add(features1.m_intDistractorNum);
            lsFeatures1.Add(features1.m_intLinguisticCategory);
            
            lsFeatures2.Add(features2.m_intFrequency);
            lsFeatures2.Add(features2.m_intConcreteness);
            lsFeatures2.Add(features2.m_intDistractorNum);
            lsFeatures2.Add(features2.m_intLinguisticCategory);
            
            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(lsFeatures1, lsFeatures2), 4);

            return dSimilarity;
        }

        //----------------------------------------------------------------------------------------------------
        // directoryCopy
        //----------------------------------------------------------------------------------------------------
        public void directoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    directoryCopy(subdir.FullName, destDirName, copySubDirs);
                    //directoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // checkAudioImage
        //----------------------------------------------------------------------------------------------------
        public void checkAudioImage()
        {
            loadChallengeItems();

            List<string> lsAudio = new List<string>();
            List<string> lsImage = new List<string>();

            for (var i = 0; i < m_lsChallengeItem.Count; i++)
            {
                for (var j = 0; j < m_lsChallengeItem[i].m_lsAudioFile.Count; j++)
                {
                    // check if file exists
                    string strAudioFile = "audio/" + m_lsChallengeItem[i].m_lsAudioFile[j] + ".wav";
                    if (!System.IO.File.Exists(strAudioFile))
                        lsAudio.Add(m_lsChallengeItem[i].m_strLinguisticCategoryName + " - " + m_lsChallengeItem[i].m_strName + " - " + m_lsChallengeItem[i].m_lsAudioFile[j]);
                }

                for (var j = 0; j < m_lsChallengeItem[i].m_lsPictureChoice.Count; j++)
                {
                    // check if file exists
                    string strImageFile = "image/" + m_lsChallengeItem[i].m_lsPictureChoice[j].m_strImageFile + ".jpg";
                    if (!System.IO.File.Exists(strImageFile))
                        lsImage.Add(m_lsChallengeItem[i].m_strLinguisticCategoryName + " - " + m_lsChallengeItem[i].m_strName + " - " + m_lsChallengeItem[i].m_lsPictureChoice[j].m_strImageFile);
                }
            }

            // write to file
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("missing_audio.txt"))
            {
                for (var i = 0; i < lsAudio.Count; i++)                
                    sw.WriteLine(lsAudio[i]);                
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("missing_image.txt"))
            {
                for (var i = 0; i < lsImage.Count; i++)
                    sw.WriteLine(lsImage[i]);
            }

        }

        //----------------------------------------------------------------------------------------------------
        // generateStarterPool
        //----------------------------------------------------------------------------------------------------
        public void generateStarterPool()
        {
            loadChallengeItems();
            loadChallengeItemFeatures();

            string strWholeFile = System.IO.File.ReadAllText("stimuli_setA/starter_pool_word_phrase_csv.csv");

            List<int> lsStarterPool_cifIdx = new List<int>();

            /*
                2,hospital,,Linguistic unit,P type,Image ID,Audio ID,Freq bin,Conc bin,Syllable
                ,,Target,hospital,target,156022646,,8,7,3
                ,,P1,hostel,distant,230648185,,,,
                ,,P2,hosepipe,distant,106051277,, ,,
                ,,P3,x,x,x,,,,
                ,,S1,ambulance,assoc,35015805,,,,
                ,,S2,stethoscope,assoc,173685527,,,,
                ,,Un,x,x,x,,,,
                ,,Un,car,un,9545845848,,,,
                ,,,,,,,,,
            */

            // split into lines
            strWholeFile = strWholeFile.Replace('\n', '\r');
            string[] lines = strWholeFile.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // see how many rows & columns there are
            int intNumRows = lines.Length;
            int intNumCols = lines[0].Split(',').Length;

            int i = 0;
            while (i < intNumRows)
            {
                if ((i % 10) == 0) // each stimulus set has 10 lines
                {            
                    i++; // skip first line
                    for (int j = 1; j < 9; j++)
                    {
                        string[] line_r = lines[i].Split(',');
                        //if (line_r[2] == "Target")
                        //    line_r[2] = "target";

                        // ,,Target,hospital,target,156022646,,8,7,3
                        if (j == 1)
                        {
                            string strChallengeItemName = line_r[3];
                            //strChallengeItemName = strChallengeItemName.ToLower();

                            int intIdx = m_lsChallengeItem.FindIndex(a => a.m_strName.Equals(strChallengeItemName));
                            if (intIdx > -1)
                            {
                                for (int k = 0; k < m_lsChallengeItem[intIdx].m_lsChallengeItemFeaturesIdx.Count; k++)
                                {
                                    int intFeatureIdx = m_lsChallengeItem[intIdx].m_lsChallengeItemFeaturesIdx[k];
                                    if (m_lsChallengeItemFeatures[intFeatureIdx].m_dComplexity_DistractorNum == 0.1)
                                    {
                                        lsStarterPool_cifIdx.Add(intFeatureIdx);
                                        Console.WriteLine("starter pool add - " + strChallengeItemName + " - " + m_lsChallengeItem[intIdx].m_strName + " - " + intFeatureIdx);
                                        break;                                    
                                    }
                                }
                            }                            
                        }                        
                        i++;
                    }                
                    i++; // skip the last empty line
                }
            }    // end while

            // save file
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(m_strFile_ChallengeItemFeature_Starterpool_Csv))
            {
                for (var m = 0; m < lsStarterPool_cifIdx.Count; m++)
                {
                    string strRow = lsStarterPool_cifIdx[m] + ",";
                    // write to file
                    sw.WriteLine(strRow);
                }
            }
        }

        class CCifComplexity
        {
            public int m_intChallengeItemFeaturesIdx = 0;
            public double m_dComplexity = 0;
        }

        //----------------------------------------------------------------------------------------------------
        // generateMedianPool
        //----------------------------------------------------------------------------------------------------
        public void generateMedianPool()
        {            
            loadChallengeItemFeatures();

            List<CCifComplexity> lsFeatures = new List<CCifComplexity>();
            for (var i = 0; i < m_lsChallengeItemFeatures.Count; i++)
            {
                CCifComplexity cifComplexity = new CCifComplexity();
                cifComplexity.m_intChallengeItemFeaturesIdx = i;
                cifComplexity.m_dComplexity = m_lsChallengeItemFeatures[i].m_dComplexity_Overall;
                lsFeatures.Add(cifComplexity);
            }

            int intMidPoint = lsFeatures.Count() / 2;
            List<CCifComplexity> lsFeaturesOrdered = lsFeatures.OrderBy(p => p.m_dComplexity).ToList();

            List<int> lsMedianPool_cifIdx = new List<int>();
            for (var i = intMidPoint; i < lsFeaturesOrdered.Count; i++)
            {
                lsMedianPool_cifIdx.Add(lsFeaturesOrdered[i].m_intChallengeItemFeaturesIdx);
                if (lsMedianPool_cifIdx.Count >= 50) break;
            }                

            // save file
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(m_strFile_ChallengeItemFeature_Medianpool_Csv))
            {
                for (var m = 0; m < lsMedianPool_cifIdx.Count; m++)
                {
                    string strRow = lsMedianPool_cifIdx[m] + ",";
                    // write to file
                    sw.WriteLine(strRow);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // testCosineSimilarity
        //----------------------------------------------------------------------------------------------------
        public void testCosineSimilarity()
        {
            double dSimilarity = 0;

            List<int> ls1 = new List<int>();
            ls1.Add(8);
            ls1.Add(7);
            ls1.Add(2);

            List<int> ls2 = new List<int>();
            ls2.Add(8);
            ls2.Add(7);
            ls2.Add(2);
            
            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(ls1, ls2), 4);
            Console.Write("cosine similarity 8-7-2, 8-7-2 = " + dSimilarity + "\n");

            ls1.Clear();
            ls1.Add(8);
            ls1.Add(7);
            ls1.Add(2);

            ls2.Clear();
            ls2.Add(8);
            ls2.Add(7);
            ls2.Add(3);

            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(ls1, ls2), 4);
            Console.Write("cosine similarity 8-7-2, 8-7-3 = " + dSimilarity + "\n");

            ls1.Clear();
            ls1.Add(8);
            ls1.Add(7);
            ls1.Add(2);

            ls2.Clear();
            ls2.Add(8);
            ls2.Add(6);
            ls2.Add(2);

            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(ls1, ls2), 4);
            Console.Write("cosine similarity 8-7-2, 8-6-2 = " + dSimilarity + "\n");

            ls1.Clear();
            ls1.Add(8);
            ls1.Add(7);
            ls1.Add(2);

            ls2.Clear();
            ls2.Add(7);
            ls2.Add(7);
            ls2.Add(2);

            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(ls1, ls2), 4);
            Console.Write("cosine similarity 8-7-2, 7-7-2 = " + dSimilarity + "\n");

            ls1.Clear();
            ls1.Add(8);
            ls1.Add(7);
            ls1.Add(2);

            ls2.Clear();
            ls2.Add(1);
            ls2.Add(1);
            ls2.Add(5);

            dSimilarity = Math.Round(CCosineSimilarity.GetCosineSimilarity(ls1, ls2), 4);
            Console.Write("cosine similarity 8-7-2, 1-1-5 = " + dSimilarity + "\n");

        }

    }
}
