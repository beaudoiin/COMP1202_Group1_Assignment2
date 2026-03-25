# IMPORTANT NOTICE
Since this is an implimentation into a new program, there is some house keeping to do!
First the origonal intent of the program was to pick the language in one large file. Below assumes you will change the functionality of that method to instead
look for xml files inside the language folder and only load that particular langauge. However, you can choose to keep everything in one file and have
multiple <en></en><de></de> type tags within the <lang> tag. If this is the case, keep in mind some of the below may not apply, where not applicable anymore.

# Using Langauges and Dictionaries by Eric
I have included a french dictionary as a starting point to see how to format xml for dictionaries. JSON could also be used for this purpose.
I have also included a helper method for converting dictionaries esier. How to use it is sumeriesed below:
* Create a defaultEnglishDictionary that contains an entry and Key for every entry in an Enum that stores the programs string labels. 
I have generally called this MessageEnum, a label might look like System_Greeting or System_Error_Exception_fileNotFound. You can use your own naming convention Just be sure to be consistant.
Current naming convention is CamelCase with _ (snake) to seperate componenets of it.

* Now that you have a proper dictionary with all entries, you can now create a new dictionary calling it w/e you like, I prefer frOutputMessages.
* Create a string that defines the ISO 639 language code you are translating for. this will be a tag wrapping the language. for example spanish is <es></es>,
some can be longer if there is veriatins youa re writing for, this is not exactly restricted to 2 codes as I programmed it to be more robust.

* Next you paste the english dictionary to an AI service and you ask it to convert. Ask it to return frOutputMessages.Add following the same enums in english and the respective translation.
* You may do this in chunks and paste in code, if anything is missing the method will alert you, and you can fix as you go. Some Ai tend to generate around 50 at a time,
up to 150 depending on the langauge and AI "mood".
* After you have all the adds, paste it back to AI to compare the formality if the language and if its accurate. (Best is getting a native speaker to audit the list)
* Now that you have a populated dictionary, when you run the method it should write an appropariate file to put in the Language folder.

# How the dictionary is loaded

The program will look in the Language folder, find the xml and itterate through each decendent of the child of lang.
If a record is missing the defualtEnglish will be used, otherwise this message will be used and loaded into the outputMessage dictionary.
A good way to assist in converting langauges quickly is to mimic the defaultEnglishMessage dictionary with .Add into a french one, then write a script
that will take each record and convert it to the xml and write it in a file. Before converting, each dictionary is compared, if a Key is missing,
or extra an error will determine which one and alert the user so that they do not have Duplicate keys, Extra Keys, or Missing Keys. Extra Keys may not
necasarily pose a problem, nor will missing keys, but extra keys can cause exceptions.
Below can be overridden or updated, this is just a demo. Upon updating, change this comment to reflect that.

The program gets a hardcoded list of langagues to give a breif discription, (about 80 langauges) based on the current culture of the computer user.
Also the program will highlight in the list the current culture of the user to aid in finding their langauge faster.
This selection can be saved on a configuration file on selection, and a flag can be used to run this langauge selection in the options to bypass auto lading based
on file. Essentially you have to save the file, and implement a boolean that states you are not using it on start up.

# Benifit
* Multi-lingual support
* User defined langauges for customization