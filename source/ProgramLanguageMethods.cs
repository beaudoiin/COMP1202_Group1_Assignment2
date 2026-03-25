using namespace assignment2 {
    internal partial class Program() {
        /// <summary>
        /// If config file exists it will try to load the language specified in the config file, if it fails it will fall back to the default english dictionary and overwrite the config file with the default english language code.
        /// If the config is laoded it will prompt the user to select a language from the list of languages in the xml file, and save the selected language to the config file for next time. If the user selects a language that is not in the xml file, it will fall back to the default english dictionary and overwrite the config file with the default english language code.
        /// If the config file is bypassed it will prompt the user to select a language from the list of languages in the xml file, and save the selected language to the config file for next time. If the user selects a language that is not in the xml file, it will fall back to the default english dictionary and overwrite the config file with the default english language code.
        /// This by pass is used by the Options menu to allow the user to change their language without having to delete the config file or manually change the language code in the config file.
        /// </summary>
        /// <returns>language is 2 letter stirng</returns>
        static void ChooseLanguage( ConsoleColor [ ]? errorFgAndBg = null, ConsoleColor [ ]? prevFgAndBg = null, ConsoleColor [ ]? headerFgAndBg = null, ConsoleColor [ ]? highlightFgAndBg = null, bool bypassConfig = false ) {
            Console.Write( "\x1b[3J" ); Console.Clear();
            string languageName = "";
            string fallthrough = defaultEnglishMessages [ MessageEnum.ChooseLang_RevertingToEng ];
            List<string>? langsFoundLabelsTry;
            List<string> langsFoundLabels = new();
            Dictionary<string, string> dict;
            Dictionary<string, string> ChooseLanguagePrompt = new();
            bool exceptionCaught = false;
            //important must call this first to load the instructions in various languages.
            defineDefaultInstruction();
            string langKey = string.IsNullOrWhiteSpace( language ) ? CultureInfo.CurrentUICulture.TwoLetterISOLanguageName : language;
            string currentCultureInstruction = ChooseLanguagePrompt.TryGetValue( langKey, out var msg ) ? msg : ChooseLanguagePrompt [ "en" ];
            var xdoc = new XDocument();
            //Load config file with langauge if it exists already
            bool refPW = false; //placeholder, password hardcoded should be fine
            bool loadLanguageOptionsListFromFile = false;
            Configuration? loadedConfig = SecureFile.Load<Configuration>( s_configFile, ref refPW );
            if ( loadedConfig is not null && !bypassConfig ) {
                config = loadedConfig;
                loadLanguageOptionsListFromFile = true;
            }
            if ( !loadLanguageOptionsListFromFile ) {
                Console.Write( "\x1b[3J" ); Console.Clear();
                //Checks the dictionary for current language, if the key doesnt exist it will catch and use defualt english hardcoded
                try {
                    ColorConsole.Write( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.ChooseLang_Header ]} {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} \n", colorByGroup [ ColorGroup.MenuItems ] );
                }
                catch ( Exception ) {
                    ColorConsole.Write( $"{defaultEnglishMessages [ MessageEnum.Menu_HeaderOuterDecor ]} {defaultEnglishMessages [ MessageEnum.ChooseLang_Header ]} {defaultEnglishMessages [ MessageEnum.Menu_HeaderOuterDecor ]} \n", colorByGroup [ ColorGroup.MenuItems ] );
                }
                ThreadSleepAndClearKeys( 500 );
            }
            try {
                xdoc = XDocument.Parse( langFile ); //Load the language file
                short selectedListNumber;
                //Get langauges in the file
                langsFoundLabelsTry = xdoc.Root?
                                       .Elements()
                                        .Select( e => e.Name.LocalName ?? string.Empty )
                                        .ToList();
                int i = 0;
                List<string [ ]> langaugeCodeAndName = new();
                //list the langages
                if ( !loadLanguageOptionsListFromFile ) {
                    foreach ( var e in langsFoundLabelsTry ) {
                        ThreadSleepAndClearKeys( 7 );
                        i++;
                        try {
                            langaugeCodeAndName.Add(
                            !string.IsNullOrWhiteSpace( CultureInfo.GetCultureInfo( e ).NativeName )
                                ? new [ ] { e, char.ToUpper( CultureInfo.GetCultureInfo( e ).NativeName.First() ) + CultureInfo.GetCultureInfo( e ).NativeName.Substring( 1 ) }
                                : new [ ] { e, char.ToUpper( CultureInfo.GetCultureInfo( e ).NativeName.First() ) + CultureInfo.GetCultureInfo( e ).EnglishName.Substring( 1 ) } );
                        }
                        catch ( Exception ) {
                            langaugeCodeAndName.Add( new [ ] { e, e } );
                            //tries the current langauge, if there is no key it will use defualt
                            try {
                                Console.WriteLine( $"{messageOutput [ MessageEnum.Warning_CultureNotFound ]} : {e}" );
                            }
                            catch ( Exception ) {
                                Console.WriteLine( $"{defaultEnglishMessages [ MessageEnum.Warning_CultureNotFound ]} : {e}" );
                            }

                        }
                        langsFoundLabels.Add( e );
                        //Highlight the current culture in the list, to make it esier find their language
                        if ( e.Equals( CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.Substring( 0, 2 ), StringComparison.OrdinalIgnoreCase ) )
                            ColorConsole.Write( $"\t{i}. {langaugeCodeAndName [ i - 1 ] [ 1 ]}", colorByGroup [ ColorGroup.MenuHeadings ] );
                        else
                            ColorConsole.WriteLine( $"\t{i}. {langaugeCodeAndName [ i - 1 ] [ 1 ]}" );
                    }

                    Console.WriteLine();
                    Console.Write( currentCultureInstruction );
                    //Checks users input compared to list
                }
                if ( !loadLanguageOptionsListFromFile ) {
                    while ( true ) {
                        //Numbers and Number Pad returns 0 - 8 index based on 1 - 9 input
                        if ( short.TryParse( ColorConsole.ReadLine( colorByGroup [ ColorGroup.InputStyleText ] ), out selectedListNumber ) && selectedListNumber < i + 1 && selectedListNumber > 0 )
                            break;
                        //Checks for key if not existing uses defualt
                        try {
                            ColorConsole.WriteLine( $" {messageOutput [ MessageEnum.Warning_LanguageNotInList ]} ", colorByGroup [ ColorGroup.SystemError ] );

                        }
                        catch ( Exception ) {
                            ColorConsole.WriteLine( $" {defaultEnglishMessages [ MessageEnum.Warning_LanguageNotInList ]} ", colorByGroup [ ColorGroup.SystemError ] );

                        }
                        Console.Write( currentCultureInstruction );
                    }
                    selectedListNumber--;
                    language = langaugeCodeAndName [ selectedListNumber ] [ 0 ];
                    languageName = langaugeCodeAndName [ selectedListNumber ] [ 1 ];
                } else {
                    language = config.language;
                    languageName = CultureInfo.GetCultureInfo( config.language ).NativeName;
                }
                dict = xdoc?.Root?
                           .Descendants( language )?
                           .Descendants( "item" )?
                           .Where( x => x.Attribute( "key" ) != null )
                           .ToDictionary(
                                x => x.Attribute( "key" )!.Value,
                                x => x.Element( "message" )?.Value ?? string.Empty
                             ) ?? new Dictionary<string, string>();
                messageOutput.Clear();
                foreach ( MessageEnum item in Enum.GetValues<MessageEnum>() ) {
                    if ( dict.ContainsKey( item.ToString() ) ) {
                        messageOutput.Add( item, dict [ item.ToString() ] );
                    } else {
                        if ( defaultEnglishMessages.ContainsKey( item ) ) {
                            messageOutput.Add( item, defaultEnglishMessages [ item ] );
                        } else {
                            messageOutput.Add( item, $"{{{item.ToString()}}}" );
                        }
                    }
                }
                //Add code here to load language
                config.language = language;
                SecureFile.Save( s_configFile, config );
                //just left these errors as defualt english, assuming issue with xml means its defualting to english anyways
            }
            catch ( XmlException ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Warning_XmlFormat ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( UnauthorizedAccessException ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Excel_FileNoAccessMessage ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( ArgumentException ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Warning_ArgumentIssue ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( FileNotFoundException ) { ColorConsole.Write( $" {messageOutput [ MessageEnum.Warning_FileNotFound ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( DirectoryNotFoundException ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Warning_DirectoriesNotFound ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( NullReferenceException ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Warning_FileNull ]} ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            catch ( Exception ) { ColorConsole.Write( $" {defaultEnglishMessages [ MessageEnum.Warning_GeneralException ]}  ", colorByGroup [ ColorGroup.SystemError ] ); exceptionCaught = true; }
            if ( exceptionCaught ) {
                Console.WriteLine( $" {fallthrough}" );
                messageOutput = defaultEnglishMessages;
            }
            ColorConsole.Write( $"{( ( languageName == "" ) ? "English" : languageName )} : {messageOutput [ MessageEnum.ChooseLang_LangApplied ]} ({messageOutput [ MessageEnum.Label_Press ]} : {messageOutput [ MessageEnum.System_AnyKeyToContinue ]}) ", colorByGroup [ ColorGroup.MenuItems ] );
            Console.ReadKey( true );
            Console.Write( "\x1b[3J" ); Console.Clear();
            ///Sets the foreground and background to the supplied colors, or default if not supplied.
            ///Adds a writeLine to ensure there is no color bleeding from any ConsoleWrite before.
            ///Therefore, only use console.Write before this, not WriteLine. This will drop a new line for you.
            void defineDefaultInstruction() {
                ChooseLanguagePrompt.Add( "de", "Wählen Sie eine Sprache, indem Sie die entsprechende Nummer eingeben : " );
                ChooseLanguagePrompt.Add( "it", "Scegli una lingua inserendo il numero corrispondente : " );
                ChooseLanguagePrompt.Add( "pt", "Escolha um idioma digitando o número correspondente : " );
                ChooseLanguagePrompt.Add( "nl", "Kies een taal door het overeenkomstige nummer in te voeren : " );
                ChooseLanguagePrompt.Add( "sv", "Välj ett språk genom att ange motsvarande nummer : " );
                ChooseLanguagePrompt.Add( "no", "Velg et språk ved å skrive inn det tilsvarende nummeret : " );
                ChooseLanguagePrompt.Add( "da", "Vælg et sprog ved at indtaste det tilsvarende nummer : " );
                ChooseLanguagePrompt.Add( "fi", "Valitse kieli syöttämällä vastaava numero : " );
                ChooseLanguagePrompt.Add( "is", "Veldu tungumál með því að slá inn samsvarandi númer : " );
                ChooseLanguagePrompt.Add( "ga", "Roghnaigh teanga trí an uimhir chomhfhreagrach a iontráil : " );
                ChooseLanguagePrompt.Add( "cy", "Dewiswch iaith drwy nodi'r rhif cyfatebol : " );
                ChooseLanguagePrompt.Add( "eu", "Hautatu hizkuntza dagokion zenbakia sartuta : " );
                ChooseLanguagePrompt.Add( "ca", "Tria un idioma introduint el número corresponent : " );
                ChooseLanguagePrompt.Add( "gl", "Escolle un idioma introducindo o número correspondente : " );
                ChooseLanguagePrompt.Add( "ro", "Alegeți o limbă introducând numărul corespunzător : " );
                ChooseLanguagePrompt.Add( "hu", "Válasszon nyelvet a megfelelő szám megadásával : " );
                ChooseLanguagePrompt.Add( "cs", "Vyberte jazyk zadáním odpovídajícího čísla : " );
                ChooseLanguagePrompt.Add( "sk", "Vyberte jazyk zadaním príslušného čísla : " );
                ChooseLanguagePrompt.Add( "sl", "Izberite jezik z vnosom ustrezne številke : " );
                ChooseLanguagePrompt.Add( "hr", "Odaberite jezik unosom odgovarajućeg broja : " );
                ChooseLanguagePrompt.Add( "sr", "Изаберите језик уношењем одговарајућег броја : " );
                ChooseLanguagePrompt.Add( "bg", "Изберете език, като въведете съответния номер : " );
                ChooseLanguagePrompt.Add( "mk", "Изберете јазик со внесување на соодветниот број : " );
                ChooseLanguagePrompt.Add( "el", "Επιλέξτε γλώσσα εισάγοντας τον αντίστοιχο αριθμό : " );
                ChooseLanguagePrompt.Add( "tr", "İlgili numarayı girerek bir dil seçin : " );
                ChooseLanguagePrompt.Add( "ar", "اختر لغة بإدخال الرقم المقابل : " );
                ChooseLanguagePrompt.Add( "he", "בחר שפה על ידי הזנת המספר המתאים : " );
                ChooseLanguagePrompt.Add( "fa", "با وارد کردن شماره مربوطه یک زبان را انتخاب کنید : " );
                ChooseLanguagePrompt.Add( "hi", "संबंधित संख्या दर्ज करके एक भाषा चुनें : " );
                ChooseLanguagePrompt.Add( "bn", "সংশ্লিষ্ট নম্বর লিখে একটি ভাষা নির্বাচন করুন : " );
                ChooseLanguagePrompt.Add( "ta", "தொடர்புடைய எண்ணை உள்ளிட்டு ஒரு மொழியைத் தேர்ந்தெடுக்கவும் : " );
                ChooseLanguagePrompt.Add( "te", "సంబంధిత సంఖ్యను నమోదు చేసి ఒక భాషను ఎంచుకోండి : " );
                ChooseLanguagePrompt.Add( "th", "เลือกภาษาโดยป้อนหมายเลขที่ตรงกัน : " );
                ChooseLanguagePrompt.Add( "vi", "Chọn một ngôn ngữ bằng cách nhập số tương ứng : " );
                ChooseLanguagePrompt.Add( "id", "Pilih bahasa dengan memasukkan nomor yang sesuai : " );
                ChooseLanguagePrompt.Add( "ms", "Pilih bahasa dengan memasukkan nombor yang sepadan : " );
                ChooseLanguagePrompt.Add( "ko", "해당 번호를 입력하여 언어를 선택하십시오 : " );
                ChooseLanguagePrompt.Add( "ja", "対応する番号を入力して言語を選択してください : " );
                ChooseLanguagePrompt.Add( "zh", "输入对应的数字选择一种语言 : " );
                ChooseLanguagePrompt.Add( "ru", "Выберите язык, введя соответствующий номер : " );
                ChooseLanguagePrompt.Add( "uk", "Виберіть мову, ввівши відповідний номер : " );
                ChooseLanguagePrompt.Add( "be", "Выберыце мову, увёўшы адпаведны нумар : " );
                ChooseLanguagePrompt.Add( "lt", "Pasirinkite kalbą įvesdami atitinkamą numerį : " );
                ChooseLanguagePrompt.Add( "lv", "Izvēlieties valodu, ievadot atbilstošo numuru : " );
                ChooseLanguagePrompt.Add( "et", "Valige keel, sisestades vastava numbri : " );
                ChooseLanguagePrompt.Add( "sq", "Zgjidhni një gjuhë duke futur numrin përkatës : " );
                ChooseLanguagePrompt.Add( "af", "Kies ’n taal deur die ooreenstemmende nommer in te voer : " );
                ChooseLanguagePrompt.Add( "sw", "Chagua lugha kwa kuingiza nambari inayolingana : " );
                ChooseLanguagePrompt.Add( "zu", "Khetha ulimi ngokufaka inombolo ehambisanayo : " );
                ChooseLanguagePrompt.Add( "xh", "Khetha ulwimi ngokufaka inombolo ehambelanayo : " );
                ChooseLanguagePrompt.Add( "am", "ተመሳሳይ ቁጥሩን በመግባት ቋንቋ ይምረጡ : " );
                ChooseLanguagePrompt.Add( "ne", "सम्बन्धित नम्बर प्रविष्ट गरेर भाषा छान्नुहोस् : " );
                ChooseLanguagePrompt.Add( "si", "අදාළ අංකය ඇතුළත් කර භාෂාවක් තෝරන්න : " );
                ChooseLanguagePrompt.Add( "km", "ជ្រើសរើសភាសាដោយបញ្ចូលលេខដែលត្រូវគ្នា : " );
                ChooseLanguagePrompt.Add( "lo", "ເລືອກພາສາໂດຍໃສ່ເລກທີ່ກົງກັນ : " );
                ChooseLanguagePrompt.Add( "mn", "Харгалзах дугаарыг оруулж хэл сонгоно уу : " );
                ChooseLanguagePrompt.Add( "kk", "Сәйкес нөмірді енгізу арқылы тілді таңдаңыз : " );
                ChooseLanguagePrompt.Add( "uz", "Mos raqamni kiritib tilni tanlang : " );
                ChooseLanguagePrompt.Add( "az", "Uyğun nömrəni daxil edərək dili seçin : " );
                ChooseLanguagePrompt.Add( "ka", "აირჩიეთ ენა შესაბამისი ნომრის შეყვანით : " );
                ChooseLanguagePrompt.Add( "hy", "Ընտրեք լեզուն՝ մուտքագրելով համապատասխան համարը : " );
                ChooseLanguagePrompt.Add( "ur", "متعلقہ نمبر درج کر کے زبان منتخب کریں : " );
                ChooseLanguagePrompt.Add( "ps", "د اړوند شمېرې په داخلولو سره ژبه وټاکئ : " );
                ChooseLanguagePrompt.Add( "my", "သက်ဆိုင်ရာ နံပါတ်ကို ထည့်၍ ဘာသာစကားကို ရွေးချယ်ပါ : " );
                ChooseLanguagePrompt.Add( "en", "Choose a language by entering the corresponding number : " );
                ChooseLanguagePrompt.Add( "fr", "Choisissez une langue en entrant le numéro correspondant : " );
                ChooseLanguagePrompt.Add( "es", "Elija un idioma ingresando el número correspondiente : " );
                ChooseLanguagePrompt.Add( "pl", "Wybierz język, wpisując odpowiadający numer : " );
            }
        }
        /// <summary>
        /// Primary code used to load Files, with password protection and a cooldown timer after a certain number of failed attempts.
        /// This code is specifically talored to loading the Transactions file and the Budget file, with some options for if one is
        /// found and not the other, and options to load sample data if the user can't remember their password or doesn't have a file.
        /// Loading sample data or no data still prompts for a password which will be used for the new file saved once they modify
        /// transactions or budgets, this is to keep the flow of the program consistent and to make sure the user has a password set up
        /// even if they don't have a file or can't remember the password for their file.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// //ChatGpt Tool for converting languages quickly, Converts a dictionary to xml. read comments inside
        /// Not currently in use, this is a DEV tool, just like sampleData (which is in use)
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="twoCharLanguageCode"></param>
        /// <param name="filePath"></param>
        private static void ExportLanguageFile() {
            string twoCharLanguageCode = "hi";   // change when generating another language, the last one I did was hindi.

            Dictionary<MessageEnum, string> english = defaultEnglishMessages;
            Dictionary<MessageEnum, string> lang = new() {
                //Translate the enire english dictionary keys and strings exactly to here in a new language. This will format to XML, and you can copy that
                //into the language file. Good for using AI to present data in simple dictionary add statements. AI can manage translations better that way.
                //This method was used to generate the 7 languages seen here. Modifactions can be done and updates using regex directly on the file after, or
                //use this.
            };
            bool error = false;

            if ( english.Count != lang.Count ) {
                Console.WriteLine( $"Dictionary size mismatch! English={english.Count} Lang={lang.Count}" );
                error = true;
            }

            foreach ( var key in english.Keys ) {
                if ( !lang.ContainsKey( key ) ) {
                    Console.WriteLine( $"Missing key: {key}" );
                    error = true;
                }
            }

            foreach ( var key in lang.Keys ) {
                if ( !english.ContainsKey( key ) ) {
                    Console.WriteLine( $"Extra key in language file: {key}" );
                    error = true;
                }
            }

            if ( error ) {
                Console.WriteLine( "\nDictionary mismatch detected. Press any key to halt." );
                Console.ReadKey( true );
                return;
            }

            using StreamWriter writer = new( "language_export.xml" );

            writer.WriteLine( $"<{twoCharLanguageCode}>" );

            string currentGroup = "";

            foreach ( var pair in lang.OrderBy( p => p.Key.ToString() ) ) {
                string key = pair.Key.ToString();
                string value = pair.Value;

                int split = key.IndexOf( '_' );
                string group = split > 0 ? key.Substring( 0, split ) : key;

                if ( group != currentGroup ) {
                    writer.WriteLine( $"<!-- {group} -->" );
                    currentGroup = group;
                }

                writer.WriteLine( $"  <item key=\"{key}\">" );
                writer.WriteLine( $"      <message>{value}</message>" );
                writer.WriteLine( $"  </item>" );
            }

            writer.WriteLine( $"</{twoCharLanguageCode}>" );
        }

    }
}