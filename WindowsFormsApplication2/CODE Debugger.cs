///Name : Hussien Tarek.
///Date of last Update : 8/8/2018.
///


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication2
{
    class CODE
    {
        
        /// <summary>
        /// increment or decrement code by number of steps
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="step">step</param>
        /// <param name="Inc">boolean that determine that determine whether increment or decrement</param>
        /// <returns>returns code after increment or decrement</returns>
        public string CodeManipulator(string code, string step, bool Inc,Label lbl_debug_steps)
        {
            int err_id, ind;
            string err_message;
            if (validation(code, step, out ind, out err_id, out err_message))
            {
                if (Inc)//check if the code will be incremented.
                {
                    return increment(code, Convert.ToInt32(step), lbl_debug_steps);//return code after incrementing.
                }
                else
                {
                    return decrement(code, Convert.ToInt32(step), lbl_debug_steps);//return code after decrementing.
                }
            }
            return "index : " + ind + ", Error : " + err_id + " : " + err_message; 

        }
        //code validation methodes:
        public bool validation(string code,string step,out int ind,out int err_id, out string err_message)
        {
            ind = -1;
            if(CodeVildation(code,out ind,out err_id,out err_message))
            {
                if (StepValidation(step, out err_id, out err_message))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// check whether code is valid or not,save index of char that cause error if there's & save error message & it's id in variables.
        /// Error messages list:
        /// err_id | err_message
        ///   0    | success.
        ///   1    | empty field.
        ///   2    | code length is out of range.
        ///   3    | seperator duplication.
        ///   4    | invalid character.
        ///   5    | special character.
        ///   6    | starting with seperator
        ///   7    | ending with seperator
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="ind">index of invalid letter</param>
        /// <param name="err_id">id of error</param>
        /// <param name="err_message">error message</param>
        /// <returns>(true) if valid or (false) if invalid</returns>
        public bool CodeVildation(string code,out int ind,out int err_id,out string err_message)
        {
            code = code.Trim();
            bool dublication;// declare boolean that will be used in CodeRange methode to determine whether error was of seperator dublication or special char.
            if (code.Length > 0 && code.Length <= 50) // check whether the code length within range from 1 to 50.
            {
                if (CodeRange(code, out ind, out dublication))// check whether the code consists of slash,dash,numbers & alphabets only
                                                              //and dosen't contain successive dashs or slashs.
                {
                    if (code[0] != '/' && code[0] != '-')// check whether the code dosen't start with dash or slash.
                    {
                        if (code[code.Length - 1] != '-' && code[code.Length - 1] != '/')
                        // check whether the code dosen't end with dash or slash.
                        {
                            ind = -1;// set ind variable with -1 as there's no invalid char.
                            err_id = 0;// set id of error message.
                            err_message = "success.";//set error message to indicate success.
                            return true;
                        }
                        else
                        {
                            ind = code.Length - 1;// set ind variable with index at last of code.
                            err_id = 7;// set id of error message.
                            err_message = "ending with seperator.";// set error message to indicate error type.
                            return false;
                        }
                    }
                    else
                    {
                        ind = 0;// set ind with value of index of start of code.
                        err_id = 6;// set id of error message.
                        err_message = "starting with seperator.";// set error message to indicate error type.
                        return false;
                    }
                }
                else
                {
                    if (dublication)//check whether error because of the seperator dublication.
                    {
                        err_id = 3;// set id of error message.
                        err_message = "seperator dublication.";// set error message to indicate error type.
                    }
                    else
                    {
                        string SChars = "!\"#$%&'()*+,-.:;<=>?@[\\]^_`{|}~";//set string contian special chars.
                        if (Array.IndexOf(SChars.ToCharArray(), code[ind]) == -1)//check whether the char that was invalid is special or not.
                        {
                            err_message = "invalid character.";// set error message to indicate error type.
                            err_id = 4;// set id of error message.
                        }
                        else
                        {
                            err_message = "special character.";// set error message to indicate error type.
                            err_id = 5;// set id of error message.
                        }
                    }
                    return false;
                }
            }
            else
            {
                ind = -1;// set ind with -1 value as the code is invalid because it's length is out of range.
                if (code.Length == 0)
                {
                    err_id = 1;// set id of error message.
                    err_message = "Empty Field.";// set error message to indicate error type.
                }
                else
                {
                    err_id = 2;// set id of error message.
                    err_message = "code length is out of range.";// set error message to indicate error type.
                }
                return false;
            }    
        }
        /// <summary>
        /// check if code within validation range(alphabets,numbers,slashs & dashs) & dosen't contain succesive
        /// dash or slash, save index of special char or first dublication char & indicate whether dublication occur.
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="ind">index of out range char or the first char in two succesive dashs or slashs</param>
        /// <param name="dublication">boolean check whether seperator dublication occur</param>
        /// <returns>(true) if it's within validation range & has no successive dashs or slashs otherwise (false)</returns>
        public bool CodeRange(string code,out int ind,out bool dublication)
        {
            for(int i = 0; i < code.Length; i++)//loops on each character in the string to check it.
            {
                if (!((code[i] >= 'A' && code[i] <= 'Z') || (code[i] >= 'a' && code[i] <= 'z') || (code[i] == '/') || (code[i] == '-') || (code[i] >= '0' && code[i] <= '9')))
                //check whether each character isn't within validation range.
                {
                    ind = i;// set ind variable with index value of the character that not within validation range.
                    dublication = false;//set that no dublication occur.
                    return false;
                }
                else if(i != code.Length - 1 )//check that index isn't the index of last character in the string.  
                {
                    if ((code[i] == '-' && (code[i + 1] == '-' || code[i + 1] == '/')) || (code[i] == '/' && (code[i + 1] == '-' || code[i + 1] == '/')))
                    //check if seprator dubliction occur.
                    {
                        ind = i;// set ind variable with index value of charater that is slash or dash & followed by either one of them.
                        dublication = true;// set that dublictaion occur.
                        return false;// return false as the string contians successive dashs or slashs.
                    }
                } 
            }
            dublication = false;//set that no dublication occur.
            ind = -1;// set ind equal -1 as there's no char out of range & no dublication occur.
            return true;// returns true in case loop is ended & the methode didn't end & return false.
        }

        //step validation methodes:
        /// <summary>
        /// check whether step is valid or invalid.
        /// Error messages list:
        /// err_id | err_message
        ///   0    | success.
        ///   1    | Empty field.
        ///   2    | special character.
        ///   3    | step value is out of range.
        /// </summary>
        /// <param name="step">step</param>
        /// <returns>(true) if step is valid & (false) if step is invalid</returns>
        public bool StepValidation(string step,out int err_id, out string err_message)
        {
            step = step.Trim();
            /* if(step.Length <= 2)// check that length of step string is 2 or less.
            {*/
            int intstep;
                if (int.TryParse(step,out intstep))// check that step string consists of numbers only and can be converted.
                {
                    if (intstep > 0 && intstep <= 50)// check that step value larger than zero and less than 50.
                    {
                        err_id = 0;// set id of error message.
                    err_message = "success.";// set error message to indicate error type.
                        return true;
                    }
                    else
                    {
                        err_id = 3;// set id of error message.
                    err_message = "step value is out of range."; ;// set error message to indicate error type.
                    return false;
                    }

                }
                else
                {
                    if (step == "")
                    {
                        err_id = 1;// set id of error message.
                        err_message = "Empty field";// set error message to indicate error type.
                        return false;
                    }
                    else
                    {
                        err_id = 2;// set id of error message.
                        err_message = "invalid char(numbers only are allowed)";// set error message to indicate error type.
                        return false;
                    }
                }
            /*}
            else
            {
                err_id = 1;
                err_message = "step length is out of range.";
                return false;
            } */
        }
        /// <summary>
        /// check that step string consists of numbers only. 
        /// </summary>
        /// <param name="code">step</param>
        /// <returns>(true) if step contians numbers only otherwise (false)</returns>
        public bool StepRange(string step)
        {
            for (int i = 0; i < step.Length; i++)// loop each char in step string.
            {
                if (!(step[i] >= '0' && step[i] <= '9') )//check if char isn't number.
                {
                    return false;
                }
            }
            return true;
        }

        //increment methodes:
        /// <summary>
        /// increment the number char of index ind in code as much as it can carry from the step & change code to suit it.
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="step">the number of steps of incrementation</param>
        /// <param name="ind">index of the char that should be incremented</param>
        /// <returns>new code after the char of index ind is incremented </returns>
        public string IncCharNum (string code , ref int step , ref int ind)
        {
            char[] codearr = code.ToCharArray();// set the string code in char array to be able to modify it.
            int NumericalValue = (int)Char.GetNumericValue(codearr[ind]);//convert the char into int & set in variable.
            codearr[ind] = char.Parse(((NumericalValue + step) % 10).ToString());//set the char by the number results
            //from summation of NumerricalValue & Step remainder 10 to get the value of the cahr after incrementation .
            step = (NumericalValue + step) / 10;// set step equals summation step & NumericalValue divided by 10 to 
                                               //remove from step the value added in the char.
            //note: char.prase((...).ToString())) to convert that int into char so it can be putted in array of char.
            if (step == 0)//check whether what remainded from step is zero. 
            {
                return new string(codearr);// return codearr as string.
            }
            else if(ind == 0)// check whether the char is last char in string.
            {
                if(code.Length <= 48)//check before adding new two chars to string that it's length won't exceed max
                                    // code length.
                {
                    code = new string(codearr) ;// set code string by value of codearr to update code.
                    code = "1-" + code ;// add (1-) chars to code as the string length can't cover the remainded step.
                    
                    step -= 1;//remove from step 1 value corresponding to the added one (1-).
                    return code;// return codearr as string.
                }
                else
                {
                    step = 0;// set step equal zero to stop incrementaion processes.
                    return "Incrementation is out of range";
                }
            }
            else
            {
                ind--;// change index to indicate the next char to increment it.
                return new string(codearr);//return codearr array as string format.
            }          
        }
        /// <summary>
        /// increment the alphabet char of index ind in code as much as it can carry from the step & change code to suit it.
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="step">the number of steps of incrementation</param>
        /// <param name="ind">index of the char that should be incremented</param>
        /// <returns>new code after the char of index ind is incremented</returns>
        public string IncCharAlpha(string code, ref int step, ref int ind)
        {
            char[] codearr = code.ToCharArray();// set the string code in char array to be able to modify it.
            bool Isupper = false;// set IsUpper equal to false indicate after finding order of letter in alpha whether 
                                //it was uppercase or not. 
            char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            //make array of alphabets to identify the order of the char of index ind in alphabet.
            if (Char.IsUpper(codearr[ind]))// check whether the char of index ind is Uppercase.
                Isupper = true;//set Isupper variable by true to save that it was upper before change.
            codearr[ind] = char.ToLower(codearr[ind]);// convert the char to lowercase so we can find it's position in alpha.
            int inalpha = Array.IndexOf(alpha, Char.ToLower(codearr[ind]));// set variable by index of the char in but in alpha array.
            if(Isupper)//check if the char was uppercase.
            {
                codearr[ind] = Char.ToUpper(alpha[(step + inalpha) % 26]);// setting the char in codearr by the uppercase
                 //of letter in alpha array of index of the summation of step & inalpha remainder 26 to get 
                //the corresponding letter in alpha array after incrementation.
            }
            else
            {
                codearr[ind] = alpha[(step + inalpha) % 26];// setting the char in codearr by letter in alpha array 
                //of index of the summation of step & inalpha remainder 26 the corresponding letter in alpha array after incrementation.
            }
            step = (step + inalpha) / 26;// set step equals summation step & inalpha divided by 26 to remove from step 
            //the value added in the char.
            
            if (step == 0)//Check whether step equals zero.
            {
                return new string(codearr);//retruns string of codearr char array.
            }
            else if (ind == 0)// check whether the char is last char in string.
            {
                if (code.Length <= 48)//check before adding new two chars to string that it's length won't exceed max
                                      // code length.
                {
                    code = new string(codearr);// set code string by value of codearr to update code.
                    code = "B-" + code;// add (B-) chars to code as the string length can't cover the remainded step.
                    step -= 1;//remove from step 1 value corresponding to the added one in (B-).
                    return code;
                    
                }
                else
                {
                    step = 0;// set step equal zero to stop incrementaion processes.
                    return "Incrementation is out of range";
                }
            }
            else
            {
                ind--;// change index to indicate the next char to increment it.
                return new string(codearr);//retruns string of codearr char array.
            }
        }
        /// <summary>
        /// increments String Code by number of steps.
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="step">number of steps</param>
        /// <returns>new code resulted from incrementation of step</returns>
        public string increment(string code ,int step,Label lbl_debug_steps)
        {
            code = code.Trim();
            lbl_debug_steps.Text = "";
            int ind = code.Length - 1;// set ind by index of last element to start from incrementation process.
            do
            {
                if (code[ind] >= '0' && code[ind] <= '9')//check whether the selected char is number.
                {
                    code = IncCharNum(code, ref step, ref ind);
                    //increment the number char,update code & indicate index for next char. 
                }
                else if ((code[ind] >= 'a' && code[ind] <= 'z') || (code[ind] >= 'A' && code[ind] <= 'Z'))
                //check whether the selected char is alphabet.
                {
                    code = IncCharAlpha(code, ref step, ref ind);
                    //increment the alphabet char,update code & indicate index for next char. 
                }
                else
                    ind--;//change the ind index to indicate the next char as if it's not number or alphabet so it's dash or slash.
                lbl_debug_steps.Text += code + "\n"; 
            } while (step != 0);// repeats until the step becomes zero which means that incrementation process has finished
            return code;
        }



        //decrement methodes:
        /// <summary>
        /// decrements string code by number of steps.
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="step">number of steps</param>
        /// <returns>new code resulted from decrementation of step</returns>
       public string decrement(string code,int step,Label lbl_debug_steps)
        {
            code = code.Trim();
            lbl_debug_steps.Text = "";
            bool IsDecremented = false;//set boolean by false value that will indicate whether the process is finished or not.
            int ind = code.Length - 1;// set ind by index of last element to start from decrementation process. 
            char[] codearr = code.ToCharArray() ;// set string in char array to be able to modify it.
            char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            //make array of alphabets to identify the order values of the alphabet chars ny there index in array.
            while (IsDecremented == false)//loops as far as process not finished (IsDecremented not equal true).
            {
                if (codearr[ind] >= '0' && codearr[ind] <= '9')//check whether the indicated char is num.
                {
                    codearr = DecCharNum(codearr, alpha, ref ind, ref step, ref IsDecremented);//try to apply decrementation process on indicated numerical char only & change code,step & ind to 
                                                                                        //suit the result otherwise reset code to zero values & end process of decrementation.
                }
                else if ((codearr[ind] == '/') || (codearr[ind] == '-'))//check whether the indicated char is dash or slash.
                {
                    ind--;//make index point to the following char.
                }
                else
                {
                    codearr = DecCharAlpha(codearr, alpha, ref ind, ref step, ref IsDecremented);//try to apply decrementation process on indicated alphabetical char only & change code,step & ind to 
                                                                                           //suit the result otherwise reset code to zero values & end process of decrementation.
                }
                lbl_debug_steps.Text += new string(codearr) +"\n";
            }
            return new string (codearr);// returns the char array as string.

        }
        /// <summary>
        /// apply the decrementation process on the chosed numerical char only,indicate whether operation could be proceed or not & change code to suit the process.
        /// </summary>
        /// <param name="codearr">array carry the code</param>
        /// <param name="alpha">array of all alphabet letters</param>
        /// <param name="ind">index of char that will be decremented</param>
        /// <param name="step">the number of steps</param>
        /// <param name="IsDecremented">boolean indicates if process finished</param>
        /// <returns>modified codearr after the char is decremented or after it couldn't be decremented</returns>
       public char[] DecCharNum(char[] codearr , char[] alpha , ref int ind , ref int step , ref bool IsDecremented)
        {
            int NextOldValue = 0;//container carries the old value of the char before being maximized from next chars because it's value didn't cover decrementation value.
            int dec = step % 10;//the value that should be decremented from the char.
            while(IsDecremented == false)//loops as far code won't reach minimum value & the char isn't decremented.
            {
                if ((int)Char.GetNumericValue(codearr[ind]) >= dec)// check whether the value that should be decremented from the char could be decremented from the char value.
                {
                    codearr[ind] = Char.Parse(((int)Char.GetNumericValue(codearr[ind]) + NextOldValue - dec).ToString());//set the char by char corresponding to the integer resulted from 
                    //summation of the corresponding integer for the indexed char,NextOldValue (incase the char was maximized) & -ive of dec.
                    //note: char.prase((...).ToString()) get corresponding value of integer but in datatype char.
                    //note: (int)char.GetNumericValue(...) get corresponding value of char in datatype integer.
                    step /= 10;//remove from step value decremented from the indexed char.
                    return CharDecremented(codearr, step, ref ind, ref IsDecremented);//determine whether process (completed),(not completed):refer index ind for next char or 
                    //(completed & code reach minimum): make code reach min (value = zero). 
                }
                else
                {
                    codearr = getnext(codearr, alpha, ind, ref dec, ref IsDecremented ,ref NextOldValue);
                    //try to maximize the char by values from the following chars to be able to decrement the char.
                }
            }
            return codearr;
                     
        }
        /// <summary>
        /// apply the decrementation process on the chosed alphabetical char only,indicate whether operation could be proceed or not & change code to suit the process.
        /// </summary>
        /// <param name="codearr">array carry the code</param>
        /// <param name="alpha">array of all alphabet letters</param>
        /// <param name="ind">index of char that will be decremented</param>
        /// <param name="step">the number of steps</param>
        /// <param name="IsDecremented">boolean indicates that process has finished</param>
        /// <returns>modified codearr after the char is decremented or after it couldn't be decremented</returns>
       public char[] DecCharAlpha(char[] codearr , char[] alpha ,  ref int ind , ref int step , ref bool IsDecremented)
        {
            int NextOldValue = 0;//container carries the old value of the char before being maximized from next chars because it's value didn't cover decrementation value.
            int dec = step % 26;//the value that should be decremented from the char.
            while (IsDecremented == false)//loops as far code won't reach minimum value & the char isn't decremented.
            {
                int inalpha = Array.IndexOf(alpha, Char.ToLower(codearr[ind]));//varaible saves the order of the char (in lowercase state as alpha chars all are lowercase the
                                                                               //in alpha array) to use it in decrement from it.
                if (inalpha >= dec)// check whether the value that should be decremented from the char could be decremented from the char value.
                {
                    if (Char.IsUpper(codearr[ind]))//check whether codearr is uppercase.
                        codearr[ind] = Char.ToUpper(alpha[inalpha + NextOldValue - dec]);//set the char by the uppercase of value of char that has order of summation of inalpha,NextOldValue
                                                                                        //& -ive of dec in alpha array get the char that has required value after decrement of char.
                    else
                        codearr[ind] = alpha[inalpha + NextOldValue - dec];//set the char by the lowercase of value of char that has order of summation of inalpha,NextOldValue
                                                                           //& -ive of dec in alpha array get the char that has required value after decrement of char.
                    step /= 26;//remove from step value decremented from the indexed char.
                    return CharDecremented(codearr, step, ref ind, ref IsDecremented);//determine whether process (completed),(not completed):refer index ind for next char or 
                    //(completed & code reach minimum): make code reach min (value = zero). 
                }
                else
                {
                    codearr = getnext(codearr, alpha, ind, ref dec, ref IsDecremented , ref NextOldValue);
                    //try to maximize the char by values from the following chars to be able to decrement the char.
                }
            }
            return codearr;
            
        }
        /// <summary>
        /// after decrement of the char inditfy whether process is finished or code will reach minimum (also process will be finished) or points ind to next char to continue process. 
        /// </summary>
        /// <param name="codearr">array carry the code</param>
        /// <param name="step">the number of steps</param>
        /// <param name="ind">index of char that will be decremented</param>
        /// <param name="IsDecremented">boolean indicates that process has finished</param>
        /// <returns>code minimized incase it will reach minimum or remain code constant</returns>
        public char[] CharDecremented (char[] codearr , int step , ref int ind , ref bool IsDecremented)
        {
            if(step == 0)//check whether whole step is consumed after the decrement of char.
            {
                IsDecremented = true;//end the process.
                return codearr;
            }
            else if(ind == 0)//check whether the index covered all char in array.
            {
                IsDecremented = true;//end the process.
                return codearr = (reset(new string(codearr),0)).ToCharArray();//return the array after being rested(make all it's values are zeros)
            }
            else
            {
                ind--;//point the index towards next char.
                return codearr;
            }
        }
        /// <summary>
        /// try to maximize the char that should be decremented to be able to decremente it by decrementing following char otherwise
        /// the char can't be maximized then it will reset code and end process.
        /// </summary>
        /// <param name="codearr">array carry the code</param>
        /// <param name="alpha">array of all alphabet letters</param>
        /// <param name="ind">index of char that will be decremented</param>
        /// <param name="dec">the value that should be decremented from the char</param>
        /// <param name="IsDecremented">boolean indicates that process has finished</param>
        /// <param name="NextOldValue">the value of the char before it's maximized incase it has been maximized</param>
        /// <returns>modified code after giving values from next chars to that char that will be decremented or rested code incase the following chars has values zeros</returns>
        public char[] getnext(char[] codearr , char[] alpha , int ind , ref int dec , ref bool IsDecremented , ref int NextOldValue)
        {
            if(ind != 0)//check whether the char should be decremented is last char in code.
            {
                
                bool IsGetted = false;//boolean indicates whether the process of getting values from following chars is done or not.
                int getnextInd = ind - 1;//set index for the next chars equal index of first char after the char needs to be decremented.
                while (IsGetted == false)// loops as far getting from next chars values process not finished or if it can't get values from the next chars.
                {
                    bool IsChanged = false;//boolean indicates whether the value of refered integer has changed or not. 
                    if (codearr[getnextInd] >= '0' && codearr[getnextInd] <= '9')//check whether the char that will get value from it is number.
                    {
                        int integer = (int)Char.GetNumericValue(codearr[getnextInd]);//set intger value saves the corresponding numerical value of the char as intger datatype.
                        codearr = UpdateCode(codearr, alpha, ref dec, ind, ref getnextInd, ref IsDecremented, ref IsGetted, ref integer, ref NextOldValue , ref IsChanged);
                        //try to decrement the value of the char that will be getted from it by one & the dec also by one as max value of the char that need to be decremented is 9 not 10 so
                        //the difference is covered by decrementing dec or if it could't decrement it the code is reseted & the whole process is finished.
                        if (IsChanged)//check whether the value of the integer is changed.
                        {
                            codearr[getnextInd] = Char.Parse(integer.ToString());//set value of the getting char by corresponding char for the integer after it's changed.
                        }
                            
                    }
                    else if ((codearr[getnextInd] == '/') || (codearr[getnextInd] == '-'))//check whether the getting char is dash or slash.
                    {
                        getnextInd--;// points the index for next char to get from it.
                    }
                    else
                    {
                        int inalpha = Array.IndexOf(alpha, Char.ToLower(codearr[getnextInd]));//varaible saves the order of the char (in lowercase state as alpha chars all are lowercase the
                        //in alpha array) to use it in decrement from it.
                        codearr = UpdateCode(codearr, alpha, ref dec, ind, ref getnextInd, ref IsDecremented, ref IsGetted, ref inalpha , ref NextOldValue , ref IsChanged);
                        //try to decrement the value of the char that will be getted from it by one & the dec also by one because max value of the char that need to be decremented is 25 
                        //not 26 so the difference is covered by decrementing dec or if it could't decrement it the code is reseted & the whole process is finished.
                        if (IsChanged)// check whether the value of inalpha is changed.
                        {
                            if (Char.IsUpper(codearr[getnextInd]))//check whether the getting char is uppercase. 
                            {
                                codearr[getnextInd] = Char.ToUpper(alpha[inalpha]);//set the getting char equal to the char before it (in uppercase because it was so) as the inalpha changed.
                            }
                            else
                            {
                                codearr[getnextInd] = alpha[inalpha];//set the getting char equal to the char before it as the inalpha changed.
                            }
                        }
                    }
                }
                return codearr;
            }
            else
            {
                IsDecremented = true;// end decrementation process.
                return codearr = (reset(new string(codearr),0)).ToCharArray(); //return code after reseting to zero value.
            }
        }
        /// <summary>
        /// try to decrement MinusOne by one : decrement dec by one,set that MinusOne has changed , set the getting from next process is finsihed & save value of the char that should 
        /// be decremented before maximizing it.
        /// otherwise check if there's other chars to get unit from them : point the index toward the next cha.
        /// otherwise : rest code & end process of decrementation.
        /// </summary>
        /// <param name="codearr">>array carry the code</param>
        /// <param name="alpha">array of all alphabet letters</param>
        /// <param name="dec">the value that should be decremented from the char</param>
        /// <param name="ind">index of char that will be decremented</param>
        /// <param name="getnextInd">index of the char that will get from it</param>
        /// <param name="IsDecremented">boolean indicates that process has finished</param>
        /// <param name="IsGetted">boolean indicates whether the process of getting values from following chars is done or not.</param>
        /// <param name="MinusOne">the value that should be decremented by one</param>
        /// <param name="NextOldValue">the value of the char before it's maximized incase it has been maximized</param>
        /// <param name="Ischanged">boolean indicates whther change variable has changed</param>
        /// <returns>modifided reseted code incase the code reachs minimum or same code</returns>
        public char[] UpdateCode(char[] codearr , char[] alpha , ref int dec , int ind, ref int getnextInd 
           , ref bool IsDecremented , ref bool IsGetted , ref int MinusOne , ref int NextOldValue, ref bool Ischanged)
        {
            if(MinusOne != 0)//check whether the number that will MinusOne can be decremented by one.
            {
                MinusOne--;//decrement the MinusOne to maximize the char that need to be decremnted.
                dec--;//decrement dec as the char that will be decremented it's max value is less than the value of one unit of the following char by one so difference is covered is removed from dec.
                Ischanged = true;// the number has decrmented  by one.

                if (codearr[ind] >= '0' && codearr[ind] <= '9')// check whether the char that will borrow unit from it is number.
                    NextOldValue = (int)Char.GetNumericValue(codearr[ind]);// save old value of the char that should be decremnted before it's maximized. 
                else
                    NextOldValue = Array.IndexOf(alpha,Char.ToLower(codearr[ind]));// save old value of the char that should be decremnted before it's maximized.

                codearr = max_before(codearr, ind, getnextInd);// maximize all chars from index more than getnextInd till index ind. 
                IsGetted = true ;// set that getting unit from next process is finished.
                return codearr ;
            }
            else if(getnextInd == 0)//check whether there's no other chars to get unit from them.
            {
                IsDecremented = true;//set that the process of decrementation has finished
                IsGetted = true;// set that getting unit from next process is finished.
                return codearr = (reset(new string(codearr),0)).ToCharArray(); //return code array rested to zeros 
            }
            else
            {
                getnextInd--;//point the index towards next char to get value from it.
                return codearr;
            }
        }
        /// <summary>
        /// Maximize all values of cahrs between char of index ind & char of index getnextInd including the char of index ind.
        /// </summary>
        /// <param name="codearr">array carry the code</param>
        /// <param name="ind">index of the char that should be decremnted</param>
        /// <param name="getnextInd">index of the char that borrowed from it one unit</param>
        /// <returns>code array with maximized char from index ind to index getnextInd including index Ind</returns>
        public char[] max_before(char[] codearr, int ind, int getnextInd)
        {
            
            for (int k = getnextInd + 1; k <= ind; k++)//loops from index after getnextInd till index Ind.
            {
                if (codearr[k] >= '0' && codearr[k] <= '9')//check whether the char is number.
                {
                    codearr[k] = '9';
                }
                else if (codearr[k] >= 'a' && codearr[k] <= 'z')//check whether is lowercase letter. 
                {
                    codearr[k] = 'z';
                }
                else if (codearr[k] >= 'A' && codearr[k] <= 'Z')//check whether is uppercase letter.
                {
                    codearr[k] = 'Z';
                }
            }
            return codearr ;
        }
        /// <summary>
        /// set all char in code zeros if it's number sets it (0) if it's alpha set it (a) or (A) from the char of index
        /// ind.
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="ind">index of char that setting zero value start from it</param>
        /// <returns>new string code that all it's chars (starting from char of index ind to end of code) values are zeros </returns>
        public string reset(string code, int ind)
        {
            char[] codearr = code.ToCharArray();// set the string in char array to be able to modify it.
            for (int i = ind; i < codearr.Length; i++)// loop on each char of array after char of index ind.
            {
                if (codearr[i] >= '0' && codearr[i] <= '9')// check if char is number.
                {
                    codearr[i] = '0';// set the char by ('0').
                }
                else if (codearr[i] == '/' || codearr[i] == '-')// check if char is dash or slash.
                {
                    continue;
                }
                else if (Char.IsUpper(codearr[i]))// check if the char is Uppercase alphabet.
                    codearr[i] = 'A';// set char by ('A')uppercase.
                else
                    codearr[i] = 'a';// set char by ('a')lowercase.
            }
            return new string(codearr);// return string of the char array.
        }

    }
}
