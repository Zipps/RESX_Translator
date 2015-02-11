using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.ServiceModel.Channels;
using System.ServiceModel;
using UITimer = System.Threading.Timer;

//using System.Resources;
//using System.Globalization;

namespace RESX_Translator
{
    public partial class MainForm : Form
    {
        //constants and dataTable variable for dataGrid
        const string TableName = "Resx and TM's";
        const string stringIDCol = "Name";
        const string sourceResxCol = "Source RESX";
        const string targetResxCol = "Target RESX";
        const string bingCol = "Microsoft Translator Suggestion";
        const int NumColumns = 5;

        private DataTable m_ResxTable; //stores the resx table

        private bool TMformChanged = false; //says the TM has not been changed
        private bool TargetResxChanged = false; //says the target TM has not been changed
        


        public MainForm()
        {
            InitializeComponent();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Data grid for RESX files
        {
            TargetResxChanged = true;
            TMformChanged = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Initialise everything on startup
            //Create a data table with four columns
            this.m_ResxTable = new DataTable(TableName);
            this.m_ResxTable.Columns.Add(new DataColumn(stringIDCol, Type.GetType("System.String")));
            this.m_ResxTable.Columns.Add(new DataColumn(sourceResxCol, Type.GetType("System.String")));
            this.m_ResxTable.Columns.Add(new DataColumn(targetResxCol, Type.GetType("System.String")));
            this.m_ResxTable.Columns.Add(new DataColumn(bingCol, Type.GetType("System.String")));
            DataGridViewButtonColumn useMT = new DataGridViewButtonColumn();
            useMT.Name = "Use Microsoft Translator Suggestions";
            useMT.Text = "Use this suggestion";
            useMT.UseColumnTextForButtonValue = true;
            useMT.Width = 10;
            resxGrid.DataSource = m_ResxTable;
            resxGrid.Columns.Add(useMT);

            //Change table layout
            resxGrid.Columns[stringIDCol].Width = resxGrid.Width / NumColumns;
            resxGrid.Columns[sourceResxCol].Width = resxGrid.Columns[stringIDCol].Width;
            resxGrid.Columns[targetResxCol].Width = resxGrid.Columns[stringIDCol].Width;
            resxGrid.Columns[bingCol].Width = resxGrid.Columns[stringIDCol].Width;
            
        }
        //Open the source resource file from File menu
        private void openResxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.Filter = "RESX files (*.resx)|*.resx|All files (*.*)|*.*";
            sourceResxLabel.Text = CultureInfo.InstalledUICulture.Name;//get local culture
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                m_ResxTable.Clear(); //Clears the table of data, should add save check here??

                //doc is an object of XmlDocument
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                                              
                //selects all nodes from <root> in xml
                XmlNode rootNode = doc.SelectSingleNode("//root");

                
                foreach (XmlNode dataNode in doc.SelectNodes("//root//data"))
                {
                    //Writes the "name" from the xml to the StringID column in the dataGrid
                    string name = dataNode.Attributes["name"].Value;
                    DataRow newrow = m_ResxTable.NewRow();
                    if (dataNode.Attributes["name"].Value != null)
                    {
                        newrow["Name"] = name;
                    }
                    

                    //Writes the "value" from the xml to the Source RESX column in the dataGrid
                    foreach (XmlNode childNode in dataNode.ChildNodes)
                    {
                        if (childNode.Name == "value")
                            newrow["Source RESX"] = childNode.InnerText;
                    }
                    
                    m_ResxTable.Rows.Add(newrow);
                }
                
            }
        }

        //Open TM file from File menu
        private void openTMFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.Reset();
            openFileDialog2.RestoreDirectory = false;
            openFileDialog2.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog2.Filter = "TMX files (*.tmx|*.tmx|All files (*.*)|*.*";
            DialogResult result = openFileDialog2.ShowDialog();
           
            if (result == DialogResult.OK)
            {
                //Sets the sourceResxLabel to the source language of the TM file
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog2.FileName);
                //XmlNode headerNode = doc.SelectSingleNode("//header");
                //sourceResxLabel.Text = headerNode.Attributes["srclang"].Value;
                
                //Sets the comboBox1 to the target language in the TM file.                
                foreach (XmlNode tuvNode in doc.SelectNodes("//body//tu//tuv"))
                {
                    string test = tuvNode.Attributes["xml:lang"].Value;
                    if (test != sourceResxLabel.Text) //checks to see if xml:lang is the same as the srclang, if it's not, then it adds the target langugae to the comboBox
                    {
                        if (!comboBox1.Items.Contains(test)) //checks that duplicate cultures are not added to the comboBox
                        {
                            comboBox1.Items.Add(test);
                        }                        
                    }
                }
                
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectionIndex = comboBox1.SelectedIndex;
            string selectedCulture = comboBox1.SelectedText;
        }

        //Exit program from File menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckTMChanged())
            {
                if (CheckResxChanged())
                {
                    this.Close();
                }
            }
            
        }

        //Checks if target Resx and TM file changes need to be saved when exiting using X
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckTMChanged())
                e.Cancel = true;
            
            if (!CheckResxChanged())
                e.Cancel = true;
            
        }

        //Close all currently open files from File menu and clears table
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckTMChanged())
            {
                if (CheckResxChanged())
                {
                    m_ResxTable.Clear();
                    openFileDialog1.FileName = "";
                    openFileDialog2.FileName = "";
                    comboBox1.Text = "";
                    sourceResxLabel.Text = "-";
                    comboBox1.Items.Clear();
                    TMformChanged = false;
                    TargetResxChanged = false;
                }
            }
        }

        //Save the Target RESX file
        private void saveTargetResourceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.FileName = ("NewResx." + comboBox1.Text + ".resx"); //Sets a default file name for the target resx using the target culture from the comboBox
            saveFileDialog1.Filter = "RESX File (*.resx)|*.resx";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //first we copy the source RESX file as a base for the target RESX file

                string sourceRESXfile = openFileDialog1.FileName; //add the source RESX file
                string targetRESXfile = saveFileDialog1.FileName; //creates the target RESX file
                CreateTargetResx(sourceRESXfile, targetRESXfile); //Creates the target RESX file and allows the changes to be added from the dataGrid
                TargetResxChanged = false; //No save check on exit                
            }
            saveFileDialog1.Dispose();
        }

        //Creates the target RESX file and adds the new translations from the dataGrid
        private void CreateTargetResx(string sourceRESXfile, string targetRESXfile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sourceRESXfile);

            //check that no rows still have 'No matches found'
            bool flag = false;
            foreach (DataRow dataRow in m_ResxTable.Rows)
            {
                if (dataRow[2].ToString() == "'No matches found'")
                    flag = true;
            }
            if (flag)
            {
                DialogResult result = MessageBox.Show(
                    "One or more rows have no matching translation. Do you still wish to save?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;

            }
                                    
            foreach (DataRow dr in m_ResxTable.Rows)  //Goes through each row in the dataGrid and changes the corresponding node in the target RESX with the data from the target column in the table
            {
                string StringMatch = dr[0].ToString(); //StringID of current row
                string targetTrans = dr[2].ToString(); //Target translation of current row
                
                foreach (XmlNode change in doc.SelectNodes("/root/data")) //search for node where StringID matches the node name
                {
                    string StringID = change.Attributes["name"].Value;
                                        
                    if ((String.Equals(StringID, StringMatch, StringComparison.OrdinalIgnoreCase)) && (targetTrans != "'No matches found'"))//(StringID == StringMatch)
                    {
                        change.SelectSingleNode("value").InnerText = targetTrans; //change the node to the new target translation
                        break;
                    }                    
                }
                
            }
            doc.Save(targetRESXfile);            
        }


        //Save the TM changes to new TM file
        private void saveChangesToNewTMFileToolStripMenuItem_Click(object sender, EventArgs e)
        {                       
            saveFileDialog2 = new SaveFileDialog();
            saveFileDialog2.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog2.FileName = ("Project_TM_" + comboBox1.Text + ".tmx"); //Sets a default filename when saving the new TM
            saveFileDialog2.Filter = "TMX File (*.tmx)|*.tmx";
            DialogResult result = saveFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string originalTMfile = openFileDialog2.FileName;
                string TMfileName = saveFileDialog2.FileName;
                CreateNewTM(originalTMfile, TMfileName);
                TMformChanged = false; //
            }
            saveFileDialog2.Dispose();
        }

        //Save the TM file and adds the changes in translations made
        private void CreateNewTM(string originalTMfile, string TMfileName)//
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(originalTMfile);

            //check that no rows still have 'No matches found'
            bool flag = false;
            foreach (DataRow dataRow in m_ResxTable.Rows)
            {
                if (dataRow[2].ToString() == "'No matches found'")
                    flag = true;
            }
            if (flag)
            {
                DialogResult result = MessageBox.Show(
                    "One or more rows have no matching translation. Do you still wish to save?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
                
            }

            //Add TM changes here
            foreach (DataRow dr in m_ResxTable.Rows)
            {
                string sourceText = dr[1].ToString();
                string targetText = dr[2].ToString();
                bool matchFound = false;
                bool matchFound2 = false;
                bool madeReplacement = false;

                //find an approprite tuid for a new translation
                XmlNode checkNode = doc.SelectSingleNode("/tmx/body/tu[last()]");
                string tuidCount = checkNode.Attributes["tuid"].Value;
                int newValue = Convert.ToInt32(tuidCount) + 1;
                string tuidValue = newValue.ToString();

                foreach (XmlNode tuvNode in doc.SelectNodes("/tmx/body/tu"))
                {
                    foreach (XmlNode segNode1 in tuvNode)
                    {
                        if ((String.Equals(segNode1.InnerText, sourceText, StringComparison.OrdinalIgnoreCase)) && (segNode1.Attributes["xml:lang"].Value == sourceResxLabel.Text)) //check if source text exists in TM
                        {
                            matchFound = true;
                            matchFound2 = true;
                        }
                    }
                    foreach (XmlNode segNode in tuvNode)
                    {
                        if ((matchFound) && (segNode.Attributes["xml:lang"].Value == comboBox1.Text) && (dr[2].ToString() != "'No matches found'")) //check if tuv node for target language exists
                        {
                            segNode.ChildNodes[0].InnerText = targetText; //replaces target value in node with target value from datagrid
                            madeReplacement = true;
                        }
                    }
                    if ((matchFound) && (!madeReplacement) && (dr[2].ToString() != "'No matches found'"))//(makeInsert)
                    {
                        XmlNode targetTuv = doc.CreateNode(XmlNodeType.Element, "tuv", null);
                        XmlAttribute targetLang = doc.CreateAttribute("xml:lang");
                        targetLang.Value = comboBox1.Text;
                        targetTuv.Attributes.Append(targetLang);
                        XmlNode targetSeg = doc.CreateNode(XmlNodeType.Element, "seg", null);
                        targetSeg.InnerText = dr[2].ToString();
                        targetTuv.AppendChild(targetSeg);
                        tuvNode.AppendChild(targetTuv);
                        break;
                    }
                    madeReplacement = false;
                    matchFound = false;
                }

                if ((!matchFound2) && (dr[2].ToString() != "'No matches found'")) //no match for source text, new tranlation is added
                {
                    XmlNode bodyNode = doc.SelectSingleNode("/tmx/body");
                    XmlNode tuNode = doc.CreateNode(XmlNodeType.Element, "tu", null);

                    //tuid number for tu node
                    XmlAttribute tuid = doc.CreateAttribute("tuid");
                    tuid.Value = tuidValue;

                    XmlNode sourcetuvNode = doc.CreateNode(XmlNodeType.Element, "tuv", null);
                    XmlNode targettuvNode = doc.CreateNode(XmlNodeType.Element, "tuv", null);

                    //xml:lang for tuv nodes
                    XmlAttribute sourcexmlLang = doc.CreateAttribute("xml:lang");
                    sourcexmlLang.Value = sourceResxLabel.Text;
                    XmlAttribute targetxmlLang = doc.CreateAttribute("xml:lang");
                    targetxmlLang.Value = comboBox1.Text;

                    XmlNode sourceSegNode = doc.CreateNode(XmlNodeType.Element, "seg", null);
                    XmlNode targetSegNode = doc.CreateNode(XmlNodeType.Element, "seg", null);
                    sourceSegNode.InnerText = sourceText;
                    targetSegNode.InnerText = targetText;

                    //Add the attributes to their corresponding node
                    tuNode.Attributes.Append(tuid);
                    sourcetuvNode.Attributes.Append(sourcexmlLang);
                    targettuvNode.Attributes.Append(targetxmlLang);

                    //Add nodes to their corresponding parent node
                    sourcetuvNode.AppendChild(sourceSegNode);
                    targettuvNode.AppendChild(targetSegNode);
                    tuNode.AppendChild(sourcetuvNode);
                    tuNode.AppendChild(targettuvNode);

                    bodyNode.AppendChild(tuNode);

                }


            }
            doc.Save(TMfileName);
        }

        //Save the TM changes to the existing TM file
        private void saveTMFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check before overwritting existing TM file
            DialogResult result = MessageBox.Show(
                    "Do you really wish to overwrite current TM file?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string TMfileName = openFileDialog2.FileName;
                CreateNewTM(TMfileName, TMfileName);
                TMformChanged = false;
            }            
            
        }

        //Run translation when Translate button clicked
        private void translateButton_Click(object sender, EventArgs e)
        {            
            string sourceCulture = sourceResxLabel.Text;
            string targetCulture = comboBox1.Text;
            int count = 0;

            if (targetCulture == "") //check that a target culture has been selected from the dropdown
            {
                MessageBox.Show("No target culture has been selected or no TM file has been opened. Please open a TM file and select a target culture from the dropdown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TargetResxChanged = true;

                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog2.FileName);

                foreach (DataRow dr in m_ResxTable.Rows)  //Goes through each row in the dataGrid and performs the translation using the TM file
                {
                    
                    string sourceText = dr[1].ToString(); //text from source to be translated
                    bool matchFound = false;
                    bool transMade = false;

                    foreach (XmlNode tuvNode in doc.SelectNodes("/tmx/body/tu"))
                    {
                        foreach (XmlNode segNode1 in tuvNode)
                        {
                            if ((String.Equals(segNode1.InnerText, sourceText, StringComparison.OrdinalIgnoreCase)) && (segNode1.Attributes["xml:lang"].Value == sourceResxLabel.Text)) //matches sourceText with the node that matches the source culture
                            {
                                matchFound = true;
                            }
                        }
                        foreach (XmlNode segNode in tuvNode)
                        {                            
                            if ((matchFound) && (segNode.Attributes["xml:lang"].Value == targetCulture))
                            {
                                dr[2] = segNode.InnerText;
                                transMade = true;
                            }                            
                        }                        
                        if (transMade)
                            break;
                        if (!transMade)
                        {
                            dr[2] = "'No matches found'";                            
                        }
                        //reset bools
                        matchFound = false;
                        transMade = false;

                    }
                    if (dr[2].ToString() == "'No matches found'")
                    {
                        resxGrid.Rows[count].DefaultCellStyle.BackColor = Color.Orange; //Sets row colour to orange if there is no match found in the TM
                    }
                    count++;
                }                
            }            
        }

        //Check if changes to the TM need to be saved
        private bool CheckTMChanged()
        {
            if (TMformChanged)
            {
                DialogResult result = MessageBox.Show(
                    "The changes made by the user have not been saved to the TM. Do you still wish to exit?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }
            return true;
        }

        //Check if changes to the target resx need to be saved
        private bool CheckResxChanged()
        {
            if (TargetResxChanged)
            {
                DialogResult result = MessageBox.Show(
                    "The changes to the target resource file have not been saved. Do you still wish to exit?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }
            return true;
        }       

        //Translate all lines
        private void translateAllLinesUsingBIngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("No target culture has been selected. Please load a TM and select a target culture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
            else
            {
                foreach (DataRow dr in m_ResxTable.Rows)
                {
                    AdmAccessToken admToken;
                    if ((textBox1.Text == "")&&(textBox2.Text==""))
                    {
                        MessageBox.Show("You must enter a Client ID and Client Secret to use the Microsoft Translator service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    else
                    {
                        AdmAuthentication admAuth = new AdmAuthentication(textBox1.Text, textBox2.Text); //pleasefix: change to  use textBox values instead of mine
                        admToken = admAuth.GetAccessToken();
                    }

                    string text = dr[1].ToString();
                    string from = sourceResxLabel.Text.Substring(0, 2);
                    string to = comboBox1.Text.Substring(0, 2);

                    string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
                    string authToken = "Bearer" + " " + admToken.access_token;

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                    httpWebRequest.Headers.Add("Authorization", authToken);

                    WebResponse response = null;
                    response = httpWebRequest.GetResponse();
                    string translation = "";
                    using (Stream stream = response.GetResponseStream())
                    {
                        System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                        translation = (string)dcs.ReadObject(stream);
                    }
                    dr[3] = translation;
                }
            }
                        
        }

        //Translate missing lines
        private void translateOnlyMissingLinesUsingBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("No target culture has been selected. Please load a TM and select a target culture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (DataRow dr in m_ResxTable.Rows)
                {
                    if (dr[2].ToString() == "'No matches found'")
                    {
                        AdmAccessToken admToken;
                        //string headerValue;
                        if ((textBox1.Text == "")&&(textBox2.Text==""))
                        {
                            MessageBox.Show("You must enter a Client ID and Client Secret to use the Microsoft Translator service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        else
                        {
                            AdmAuthentication admAuth = new AdmAuthentication(textBox1.Text, textBox2.Text); //pleasefix: change to  use textBox values instead of mine
                            admToken = admAuth.GetAccessToken();
                        }
                       
                        
                        string text = dr[1].ToString();
                        string from = sourceResxLabel.Text.Substring(0, 2);
                        string to = comboBox1.Text.Substring(0, 2);

                        string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
                        string authToken = "Bearer" + " " + admToken.access_token;

                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                        httpWebRequest.Headers.Add("Authorization", authToken);

                        WebResponse response = null;
                        response = httpWebRequest.GetResponse();
                        string translation = "";
                        using (Stream stream = response.GetResponseStream())
                        {
                            System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                            translation = (string)dcs.ReadObject(stream);
                        }
                        dr[3] = translation;
                    }
                }
            }            
        }

        private void resxGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != resxGrid.Columns["Use Microsoft Translator Suggestions"].Index) return;
            if ((object)resxGrid[3, e.RowIndex].Value == DBNull.Value) //check if microsoft translation exists for that row
                MessageBox.Show("There is no Microsoft Translation for this row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //Adds text from Microsoft Translator column to the Target RESX column
                string bingText = (string)resxGrid[3, e.RowIndex].Value;
                resxGrid.Rows[e.RowIndex].Cells["Target RESX"].Value = bingText;
            }            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sourceResxLabel_Click(object sender, EventArgs e)
        {

        }
        
    }



    //Code for authentication token for Microsoft Translator
    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }
    public class AdmAuthentication
    {
        public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private string clientId;
        private string clientSecret;
        private string request;
        private AdmAccessToken token;
        private UITimer accessTokenRenewer;
        //Access token expires every 10 minutes. Renew it every 9 minutes only.
        private const int RefreshTokenDuration = 9;
        public AdmAuthentication(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            //If clientid or client secret has special characters, encode before sending request
            this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
            this.token = HttpPost(DatamarketAccessUri, this.request);
            //renew the token every specfied minutes
            accessTokenRenewer = new UITimer(new TimerCallback(OnTokenExpiredCallback), this, TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
        }
        public AdmAccessToken GetAccessToken()
        {
            return this.token;
        }
        private void RenewAccessToken()
        {
            AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
            //swap the new token with old one
            //Note: the swap is thread unsafe
            this.token = newAccessToken;
            Console.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
        }
        private void OnTokenExpiredCallback(object stateInfo)
        {
            try
            {
                RenewAccessToken();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
            }
            finally
            {
                try
                {
                    accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
                }
            }
        }
        private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
        {
            //Prepare OAuth request 
            WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
    }
}
