using System;
using System.IO;
using System.Text;

class Program
{

    public void FileOpration(string path)
    {
        string UserDataForFile;
        string UserFileName;
        char UserChoice;

    con:
        Console.WriteLine("Please Enter File Name : ");
        UserFileName = Console.ReadLine();

        //check file Exit or not
        if (!File.Exists(path + UserFileName + ".txt"))
        {
            //Create File Here
            FileStream FileCreate = new FileStream(path + UserFileName + ".txt", FileMode.Create);
            FileCreate.Close();
            Console.WriteLine("Your File is created Succesfully");
            Console.WriteLine();

            //Write Into The file
            FileStream fs = new FileStream(path + UserFileName + ".txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Enter the text which you want to write to the file");
            UserDataForFile = Console.ReadLine();
            sw.WriteLine(UserDataForFile);
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.WriteLine("File Writed Succesfully..");
            invalid:
            Console.WriteLine("Do you want to open you file:press Y for yes N for No");
            UserChoice = Console.ReadLine()[0];
            switch(UserChoice)
            {
                case 'Y':
                    ReadData(path, UserFileName, UserChoice);
                    break;
                case 'N':
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Please Enter Y or N");
                    goto invalid;
            }
        }
        else
        {
            Console.WriteLine("File Already Exits...");
            goto con;
        }
    }
    void ReadData(string path,string UserFileName, char UserChoice)
    {
        string data;
        char UChoice;
        FileStream fsSource = new FileStream(path + UserFileName + ".txt", FileMode.Open, FileAccess.Read);
        using (StreamReader sr = new StreamReader(fsSource))
        {
            data = sr.ReadToEnd();
        }
        Console.WriteLine(data);
        invalid1:
        Console.WriteLine("Do You Want to update exiting file...Press Y for Yes N For NO"); 
        UChoice = Console.ReadLine()[0];
        switch(UChoice)
        {
            case 'Y':
                string UserDataForFile2;
                //update the file
                FileStream fs = new FileStream(path + UserFileName + ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Console.WriteLine("Enter the text which you want to write to the file");
                UserDataForFile2 = Console.ReadLine();
                sw.WriteLine(UserDataForFile2);
                sw.Flush();
                sw.Close();
                fs.Close();
                Console.WriteLine("Your File was Overwrite Succesfully..");
                CopyData(path, UserFileName);
                break;
            case 'N':
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Please Enter Y or N");
                goto invalid1;
        }
        Console.ReadLine();
    }
    void CopyData(string path, string UserFileName)
    {
        string FileCopied = File.ReadAllText(path + UserFileName + ".txt");

        string UserFileNameNew;
        char UChoiceforCandP;

    invalid1:
        Console.WriteLine("Do You Want to Process Copy and Paste Data...Press Y for Yes N For NO");
        UChoiceforCandP  = Console.ReadLine()[0];
        switch (UChoiceforCandP)
        {
            case 'Y':
                cp:
                Console.WriteLine("You have to Create new File For Paste Data into it....");
                Console.WriteLine("Please Enter File Name : ");
                UserFileNameNew = Console.ReadLine();
                if (!File.Exists(path + UserFileNameNew + ".txt"))
                {
                    //Create File Here
                    FileStream FileCreateForCP = new FileStream(path + UserFileNameNew + ".txt", FileMode.Create);
                    FileCreateForCP.Close();
                    Console.WriteLine("Your File is created Succesfully....");
                    Console.WriteLine();
                    File.Copy(path + UserFileName + ".txt", path + UserFileNameNew + ".txt", true);
                    Console.WriteLine("File Copy and paste processs succesfully...");
                }
                else
                {
                    Console.WriteLine("ALready Exits....");
                    goto cp;
                }
                    break;
            case 'N':
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Please Enter Y or N");
                goto invalid1;
        }
    }
    static void Main(string[] args)
    {
        string path = @"c://";
        Program p = new Program();
        p.FileOpration(path);
    }
}
