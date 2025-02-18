using System.Text.RegularExpressions;

namespace iCal_Splitter
{   // simple version - splits file into two importable halves. User can repeat process with each resulting files (halves of halves) until desired size for import is achieved.
    public partial class Form1 : Form
    {
        static string ics_closing = "END:VCALENDAR";
        static string in_filepath = "";
        Regex valid_fformat = new Regex(".\\.ics");
        public static void ExportICS(Queue<string> one, Queue<string> two, TextBox name, Label stat)
        {
            string flname = name.Text; //make sure the user can define a name for the two ICS
            //Write to files
            // First file
            StreamWriter icsOne = new StreamWriter($@"C:\{flname}1.ics");

            try
            {
                while (one.Count > 0)
                {
                    icsOne.WriteLine(one.Dequeue());
                }
                icsOne.WriteLine(ics_closing); // complete the ICS with "END:VCALENDAR"
                icsOne.Close();
            }
            catch (Exception e)
            {

                stat.Text = "(f) " + e.Message;
            }

            // Second file
            StreamWriter icsTwo = new StreamWriter($@"C:\{flname}2.ics");

            try
            {
                while (two.Count > 0)
                {
                    icsTwo.WriteLine(two.Dequeue());
                }
                icsTwo.WriteLine(ics_closing); // complete the ICS with "END:VCALENDAR"
                icsTwo.Close();
            }
            catch (Exception e)
            {
                stat.Text = "(f) " + e.Message;
            }
        } // end of method

        public static void SplitIt(Queue<string> header, Queue<string> body, TextBox newNameBox, Label stat)
        {
            float capacity = (body.Count / 2) + header.Count + 2;
            double cap = Math.Round(capacity);

            Queue<string> fileOne = new Queue<string>();
            Queue<string> fileTwo = new Queue<string>();

            string element;
            while (header.Count > 0)
            { // make sure both files have same headers
                element = header.Dequeue();
                fileOne.Enqueue(element);
                fileTwo.Enqueue(element);
            }

            try // generate contents of first file
            {
                while (fileOne.Count < cap)
                {
                    element = body.Dequeue();
                    if (element != "END:VEVENT" && fileOne.Count == cap - 1) { cap += 1; }
                    fileOne.Enqueue(element);
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Queue empty.")
                {
                    stat.Text = "";
                }
                else { stat.Text = "(s) " + e.Message; }
            }


            try // generate contents of second file
            {
                while (fileTwo.Count < cap)
                {
                    element = body.Dequeue();
                    if (element != "END:VEVENT" && fileOne.Count == cap - 1) { cap += 1; }
                    fileTwo.Enqueue(element);
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Queue empty.")
                {
                    stat.Text = "";
                }
                else { stat.Text = "(s) " + e.Message; }
            }

            ExportICS(fileOne, fileTwo, newNameBox, stat); // call the method that generates the two separate ICS files based on the two queues created in this method
        }

        public static Queue<string> ExtractHeader(Queue<string> calbody, Label stat)
        {
            Queue<string> header = new Queue<string>();

            try
            {
                string el = "";
                while (el != null)
                {
                    if (calbody.Peek() == "BEGIN:VEVENT")
                    {
                        break;
                    }
                    else
                    {
                        el = calbody.Dequeue();
                        header.Enqueue(el);
                    }
                }
            }
            catch (Exception e)
            {
                stat.Text = "" + e.Message;
            }

            return header;

        } // end of method

        public static Queue<string> GetBody(string filepath, Label stat)
        {
            Queue<string> calendarbody = new Queue<string>();

            try // 1st read and enqueue the all lines from file
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != "END:VCALENDAR") // stop when this line reached
                    {
                        calendarbody.Enqueue(line);
                    }
                }

            }
            catch (Exception e)
            {
                stat.Text = "" + e.Message;
            }

            return calendarbody;

        } // end of method
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs ev)
        {
            try
            {
                var file = openFileDial.ShowDialog();
                in_filepath = openFileDial.FileName;
                if (String.IsNullOrEmpty(in_filepath) || valid_fformat.IsMatch(in_filepath) == false) { status.Text = "Please select a valid file."; return; };
            }
            catch (UnauthorizedAccessException)
            {
                status.Text = "Cannot access the file.";
            }

            progBox.Text += "1. " + in_filepath + " selected.";

            var b = GetBody(in_filepath, status); // 1st, read lines from .ics file
            var h = ExtractHeader(b, status); // 2nd extract and keep header in a separate queue
            SplitIt(h, b, newNameBox, status); // 3rd from header and body queues into two new queues and then export to two separate files

            // Progress messages to let the user know the job has been done.
            progBox.Text += "\n2. File split into two standalone ICS files in C:\\.\n";
            progBox.Text += "\nIf the files are still too large, repeat this process with each of them until they're small enough.\n";

            newNameBox.Clear();
        }

    }
}
