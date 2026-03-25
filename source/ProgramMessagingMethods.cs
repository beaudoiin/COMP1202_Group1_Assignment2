//Requires console color code
namespace assignment2 {
    enum ColorGroup {
            Default,
            SystemWarning,
            SystemError,
            SystemInstructions,
            SystemInstructionsGray,
            SystemPromptHint,
            SystemPromptInstructions,
            MenuHeadings,
            MenuItems,
            Success,
            Header,
            InputStyleA,
            InputStyleText
        }
        enum MessageEnum {
            #region >>> // System
            System_AnyKeyToContinue,
            System_AnyKeyToExit,
            System_YToQuitProgram,
            System_NoReleventTransactions,
            #endregion
            #region >>> // System instructions
            SystemInstructions_AnyKeyToAck,
            SystemInstructions_EscapeOrBackspace,
            SystemInstructions_ToExitOrAbort,
            SystemInstructions_InputYearForSummary,
            SystemInstructions_InputMonthForSummary,
            SystemInstructions_Abort,
            SystemInstructions_InputIncomeAmount,
            SystemInstructions_InputTransDescription,
            SystemInstructions_EnterDate,
            SystemInstructions_ToSkip,
            SystemInstructions_SpaceOrEnter,
            SystemInstructions_ToLoad,
            SystemInstructions_PageView,
            SystemInstructions_PressToExit,

            #endregion
            #region >>> // Warning
            Warning_BadDate,
            Warning_BadInput,
            Warning_DateFormat,
            Warning_DateFormatYYYY,
            Warning_EmptyOrSpaces,
            Warning_BadAmountNoZero,
            Warning_BadAmountZeroOk,
            Warning_InvalidYearOld,
            Warning_InvalidYearNew,
            Warning_InvalidMonth,
            Warning_YearTooBig,
            Warning_YearInFuture,
            Warning_SameDates,
            Warning_CultureNotFound,
            Warning_LanguageNotInList,
            Warning_XmlFormat,
            Warning_FileNotAuthorized,
            Warning_ArgumentIssue,
            Warning_FileNotFound,
            Warning_DirectoriesNotFound,
            Warning_FileNull,
            Warning_GeneralException,
            Warning_NoTransactionsOrBudgetFound,
            Warning_DeleteTransactions,

            #endregion
            #region >>> // Labels
            Label_Exit,
            Label_Enter,
            Label_Press,
            Label_toTryAgain,
            Label_LoadFile,
            Label_Skip,
            Label_Or,
            Label_And,
            Label_To,
            Label_Yes,
            Label_No,
            Label_Aborted,
            Label_TransactionAborted,
            Label_SummaryAborted,
            Label_SearchAborted,
            Label_Starting,
            Label_Options,
            Label_Date,
            Label_All,
            Label_Yearly,
            Label_Years,
            Label_Monthly,
            Label_Amount,
            Label_Description,
            Label_AddIncomeTransaction,
            Label_Income,
            Label_Total,
            Label_Balance,
            Label_AddExpenseTransaction,
            Label_Expense,
            Label_Category,
            Label_Instructions,
            Label_PageAbreviated,
            Label_TotalIncome,
            Label_TotalExpenses,
            Label_TotalBalances,
            Label_HighestExpenseCategory,
            Label_AtCostOf,
            Label_FileName,
            Label_Attempt,
            Label_SForSecond,
            Label_FileFound,
            Label_Found,

            #endregion
            #region >>> // General menu options
            Menu_Return,
            Menu_HeaderOuterDecor,
            #endregion
            #region >>> // Main Menu options
            MainMenu_Header,
            MainMenu_TransactionManagement,
            MainMenu_BudgetTools,
            MainMenu_ReportsAndSummary,
            MainMenu_Load,
            MainMenu_Save,
            MainMenu_Options,
            #endregion
            #region >>> // Transaction management options
            TransMgnt_AddIncomeTransaction,
            TransMgnt_AddExpenseTransaction,
            TransMgnt_ViewAllTransactions,
            TransMgnt_SearchTransactions,
            TransMgnt_TransactionAdded,
            TransMgnt_AddingExpenseFor,
            TransMgnt_NoDscProvided,
            TransMgnt_LabelTransCategory,


            #endregion
            #region >>> // Search by transactions
            SrcByTrans_HeaderQuestion,
            SrcByTrans_DateRange,
            SrcByTrans_PriceRange,
            SrcByTrans_Category,
            SrcByTrans_OptionOrderAsc,
            SrcByTrans_OptionOrderDesc,
            SrcByTrans_OptionTableColorBanding,
            SrcByTrans_OptionApplied,
            SrcByTrans_NoResultSrcAgain,
            SrcByTrans_SrcAborted,
            SrcByTrans_EnterDate1,
            SrcByTrans_FirstDateIs,
            SrcByTrans_EnterDate2,
            SrcByTrans_EnterAmount1,
            SrcByTrans_FirstAmountIs,
            SrcByTrans_EnterAmount2,

            #endregion
            #region >>> // Budget tools options 
            BudgetMenu_Header,
            BudgetMenu_SetMonthlyBudget,
            BudgetMenu_UpdateBudgetCateg,
            BudgetMenu_CheckRemainBudget,
            BudgetMenu_Warning80PercentOverBudget,
            BudgetMenu_CurrentBalance,
            BudgetMenu_SelectionInstruction,
            BudgetMenu_UpdateInstruction,
            BudgetMenu_WarningInstruction,
            BudgetMenu_AmountExceeded,
            BudgetMenu_AmountAccepted,
            BudgetMenu_NotUpdated,
            BudgetMenu_Updated,
            BudgetMenu_AmountInvalid,
            BudgetMenu_BudgetExceeded,
            #endregion
            #region >>> // Reports & Summary options
            ReportAndSum_AccountOverview,
            ReportAndSum_YearlySummary,
            ReportAndSum_MonthlySummary,
            ReportAndSum_SaveExcel,
            ReportAndSum_TotalIncome,
            ReportAndSum_TotalExpense,
            ReportAndSum_HighestExpenseCategory,
            ReportAndSum_AskHowToView,
            ReportAndSum_Scroll,
            ReportAndSum_Pages,
            ReportAndSum_PageAndScrollNoClear,
            ReportAndSum_NoTRansactionsInYear,
            ReportAndSum_AccountSummaryFrom,
            ReportAndSum_NoTRansactionsInMonth,
            ReportAndSum_AcountSummary,
            Excel_WorksheetNotFound,
            Excel_WelcomeMessage,
            Excel_BankRecommendations,
            Excel_BankRec1,
            Excel_BankRec2,
            Excel_BankRec3,
            Excel_BankRec4,
            Excel_BankRec5,
            Excel_BankRec6,
            Excel_BankRec7,
            Excel_EmptyMonth,
            Excel_SavedMessage,
            Excel_FileNoAccessMessage,
            #endregion
            #region >>> // Data options
            DataOptions_Header,
            DataOptions_LoadFile,
            DataOptions_LoadSample,
            DataOptions_NoloadOrSamples,
            DataOptions_WarningSavingWithNoDataMayOverwrite,
            DataOptions_DeleteTransactions,
            DataOptions_TransactionsDeleted,
            DataOptions_PrintTransactionCount,
            DataOptions_LabelAmountOfTrans,
            DataOptions_WarningThisPrintsOnlyRam,
            #endregion
            #region >>> // Menu Options
            Options_ChangLang,
            Options_AutoSave,
            #endregion
            #region >> // Get Pwd
            GetPwd_Header,
            GetPwd_PwSafteyReminder,
            GetPwd_SecurePwIsHeader,
            GetPwd_Instruction15Chars,
            GetPwd_InstructionContainDigit,
            GetPwd_InstructionSpecialChar,
            GetPwd_InstructionMixCase,
            GetPwd_EnterPw,
            GetPwd_ConfirmPw,
            GetPwd_Warning_PwDontMatch,
            GetPwd_Warning_PwDontMeetCriteria,
            GetPwd_Warning_OverOneTrillionWarning,
            GetPwd_Warning_TooManyAttempts,
            GetPwd_EnterPwTransactionFile,
            GetPwd_Warning_CoolDown,
            GetPwd_Warning_AbortWithNoTransactions,

            #endregion
            #region >>> // GetAmount, GetCategory, GetDate

            GetCategory_ChooseCategory,
            GetCategory_InstructionHowMakeChoice,
            GetDate_SameDates,
            GetDate_SearchingDatesBetween,

            #endregion
            #region >>> // ChooseLang
            ChooseLang_Header,
            ChooseLang_RevertingToEng,
            ChooseLang_LangApplied,

            #endregion

            #region >> //LoadFile
            LoadFile_AbordTransactionFileFound, //This is found in load file after cooldown when user escapes
            LoadFile_TooManyIncorrect,
            LoadFile_EnterPwForTransactionFile,
            LoadFile_IncorrectPwCoolDown,
            LoadFile_ToAbortStartNoTrans,
            LoadFile_NoTransactionsFound,
            LoadFile_ConfirmLoadingBudgetFileOnly,
            LoadFile_NoFileFound,
            LoadFile_BudgetFileFound,
            LoadFile_ConfrimLoadBudgetFile,
            LoadFile_NoTransOrBudgetFileFound,
            LoadFile_PwIncorrect,
            LoadFile_ForOtherOptionsSampleData,
            LoadFile_ConfrimTryAnotherPw,
            LoadFile_TooManyWrongPwAttempts,
            LoadFile_CooldownForNextAttempt,
            #region >> // SampleTransaction
            Sample_Header,
            Sample_Loaded,
            #endregion

            #endregion
            #region >> // Write Trans and Budget
            Write_SkipSaving,
            Write_Saved,
            #endregion
            #region >> // Budget Categories
            Category_Income,
            Category_Housing,
            Category_Groceries,
            Category_Transportation,
            Category_Utilities,
            Category_Restaurants,
            Category_Insurance,
            Category_Debt,
            Category_Entertainment,
            Category_Healthcare,
            Category_Transfers,
            Category_Fees,
            Category_Other
            #endregion
        }

        //Creates an empty dictionary to populate the active language into
        public static Dictionary<MessageEnum, string> messageOutput = new();

        // ISO 639 language code to specify language to load from xml.
        static string language = "en";
    
     // Used to populate the dictionary if the xml file is missing.
        // This allows the program to still run and display messages even if there are issues with the language file.
        // It also serves as a reference for what messages need to be included in the xml file for a new language.
        //Below is just an example
        static Dictionary<MessageEnum, string> defaultEnglishMessages = new() {
            { MessageEnum.System_AnyKeyToContinue, "Any key to continue" },
            { MessageEnum.System_AnyKeyToExit, "Any key to exit" },
            { MessageEnum.System_YToQuitProgram, "Are you sure you want to quit? (Y) to exit, any other key to continue" },
            { MessageEnum.SystemInstructions_AnyKeyToAck, "Any key to acknowledge" },
            { MessageEnum.Warning_BadInput, "Bad Input! Try again!" },
            { MessageEnum.Warning_BadAmountNoZero, "Amount must be greater than zero and cannot be blank." },
            { MessageEnum.Warning_BadAmountZeroOk, "Amount must be greater or equal to zero and cannot be blank." },
            { MessageEnum.SystemInstructions_Abort, "Type exit to abort" },
            { MessageEnum.SystemInstructions_PressToExit, "Press to exit" },
            { MessageEnum.Warning_BadDate, "Please use the proper date format" },
            { MessageEnum.Warning_DateFormat, "dd/MM/yyyy" },
            { MessageEnum.Warning_EmptyOrSpaces, "Can't be empty or spaces only!" },
            { MessageEnum.Warning_CultureNotFound, "Culture not found for" },
            { MessageEnum.Warning_LanguageNotInList, "That Language is not in the list!" },
            { MessageEnum.Warning_FileNotAuthorized, "Not authorized to access the file!" },
            { MessageEnum.Warning_ArgumentIssue, "File passed not expected format!" },
            { MessageEnum.Warning_FileNotFound, "File not found!" },
            { MessageEnum.Warning_DirectoriesNotFound, "Directories not found!" },
            { MessageEnum.Warning_FileNull, "Null exception!" },
            { MessageEnum.Warning_GeneralException, "An error occured while loading the file!" },
            { MessageEnum.SystemInstructions_EscapeOrBackspace, "Escape or Backspace" },
            { MessageEnum.SystemInstructions_ToExitOrAbort, "To exit/abort"},
            { MessageEnum.SystemInstructions_SpaceOrEnter, "Space or Enter" },
            { MessageEnum.SystemInstructions_ToSkip, "To skip" },
            { MessageEnum.SystemInstructions_ToLoad, "To load" },
            { MessageEnum.Label_toTryAgain, "To try again" },
             { MessageEnum.Label_Exit, "exit" },//intentionally lowercase
            { MessageEnum.Label_Enter, "Enter" },
            { MessageEnum.Label_Or, "or" },
            { MessageEnum.Label_To, "to" },
            { MessageEnum.Label_Yes, "Yes" },
            { MessageEnum.Label_No, "No" },
            { MessageEnum.Label_Aborted, "Aborted" },
            { MessageEnum.Label_Description, "Description" },
            { MessageEnum.Label_Press, "Press" },
            { MessageEnum.Label_Instructions, "Instructions" },
            { MessageEnum.Label_PageAbreviated, "pg." },
            { MessageEnum.Menu_Return, "Return to main menu" },
            { MessageEnum.Menu_HeaderOuterDecor, "------------" },
            { MessageEnum.MainMenu_Header, "Main menu" },
            { MessageEnum.MainMenu_Load, "Load file" },
            { MessageEnum.MainMenu_Save, "Save file" },
            { MessageEnum.MainMenu_Options, "Options" },
            { MessageEnum.TransMgnt_NoDscProvided, "No description provided" },
            { MessageEnum.SrcByTrans_OptionApplied, "Options applied" },
            { MessageEnum.DataOptions_Header, "Data Selection" },
            { MessageEnum.DataOptions_LoadFile, "Load from disk" },
            { MessageEnum.DataOptions_LoadSample, "Load sample data" },
            { MessageEnum.Write_Saved, "Saving data..." },
            { MessageEnum.Options_ChangLang, "Change language" },
            { MessageEnum.ChooseLang_Header, "Language Selection" },
            { MessageEnum.ChooseLang_RevertingToEng, "Reverting to default English Dictionary" },
            { MessageEnum.ChooseLang_LangApplied, "Langauge applied!" }
        }
             #region >>> // Console Color Control Related
        /// <summary>
        /// Dictionary for grouped colors. ColorGroup enum As Key and value is an 2 length array, Foreground ConsoleColor, and Background ConsoleColor.
        /// </summary>
        public static Dictionary<ColorGroup, ConsoleColor [ ]> colorByGroup = new() {
            {ColorGroup.Default, [ConsoleColor.White, ConsoleColor.Black ] },
            {ColorGroup.SystemWarning, [ConsoleColor.Red, ConsoleColor.Black ] },

            {ColorGroup.SystemError, [ConsoleColor.Red, ConsoleColor.White ] },
            {ColorGroup.SystemInstructions, [ConsoleColor.Cyan, ConsoleColor.Black ] },
            {ColorGroup.SystemInstructionsGray, [ConsoleColor.Gray, ConsoleColor.Black ] },
            {ColorGroup.MenuHeadings, [ConsoleColor.Cyan, ConsoleColor.Black ] },
            {ColorGroup.MenuItems, [ConsoleColor.Green, ConsoleColor.Black ] },
            {ColorGroup.Success, [ConsoleColor.Black, ConsoleColor.Yellow ] },
            {ColorGroup.Header, [ConsoleColor.Yellow, ConsoleColor.Black ] },
            {ColorGroup.InputStyleA, [ConsoleColor.Black, ConsoleColor.White ] },
            {ColorGroup.InputStyleText, [ConsoleColor.Yellow, ConsoleColor.Black ] },
            {ColorGroup.SystemPromptHint, [ConsoleColor.Gray, ConsoleColor.Black ] },
            {ColorGroup.SystemPromptInstructions, [ConsoleColor.Cyan, ConsoleColor.Black ] }
        };
        //commonly reused colors
        static ConsoleColor [ ] MenuHeadings = colorByGroup [ ColorGroup.MenuHeadings ];
        static ConsoleColor [ ] MenuItemColor = colorByGroup [ ColorGroup.MenuItems ];
        #endregion
    
    
    /*
    EXAMPLE USES OF MESSAGES AND COLORS FOR A MENU
    
            private static void TransactionManagementMenuChoice() {
           // Console.Write( "\x1b[3J" ); Console.Clear(); This just clears all console history including whats out of view, and then Console.Clear does it again encase user doesnt have ansi support and it ends up printing \x1b[3j instead
            ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.MainMenu_TransactionManagement ]} {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} ", MenuHeadings );
            ColorConsole.WriteLine( "\t1. " + messageOutput [ MessageEnum.TransMgnt_AddIncomeTransaction ], MenuItemColor, ResetColorAfter: false );
            ColorConsole.WriteLine( "\t2. " + messageOutput [ MessageEnum.TransMgnt_AddExpenseTransaction ] );
            ColorConsole.WriteLine( "\t3. " + messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ] );
            ColorConsole.WriteLine( "\t4. " + messageOutput [ MessageEnum.TransMgnt_SearchTransactions ] );
            ColorConsole.Write( $"({messageOutput [ MessageEnum.SystemInstructions_PressToExit ]} : {messageOutput [ MessageEnum.SystemInstructions_EscapeOrBackspace ]})", colorByGroup [ ColorGroup.SystemInstructionsGray ] );
            ColorConsole.Write( $" {messageOutput [ MessageEnum.Label_Press ]} 1, 2, 3, {messageOutput [ MessageEnum.Label_Or ]} 4", colorByGroup [ ColorGroup.Default ], ResetColorAfter: false );
        }

    /*
       
    /// <summary>
    /// Man program defined as partial for splitting some methods into other files. Merges back at compile time
    /// </summary>
    internal partial class Program {
        /// <summary>
        /// Prints a reusable message and asks the user to press any key to continue. This is for convenience.
        /// User can also supply a message if they want. Default is to use a dictionary item by enum 
        /// messageOutput[MessageEnum.PressAnyKeyToContinue]
        /// </summary>
        /// <param name="ClearAfter">True if you want to clear the screen after</param>
        /// <param name="BypassMsg">True if you dont want to print the suplpied message</param>
        /// <param name="WriteLine">True if you want this to be on its own line</param>
        public static void AnyKeyToContinue( bool ClearAfter = false, bool BypassMsg = false, bool WriteLine = true, string msg = "", bool DontChangeColor = false ) {

            if ( string.IsNullOrWhiteSpace( msg ) )
                //msg = $"({messageOutput [ MessageEnum.Label_Press ]} {messageOutput [ MessageEnum.System_AnyKeyToContinue ]})";
                msg = $"(Press any key to continue)";
            if ( !BypassMsg )
                if ( WriteLine ) {
                    if ( DontChangeColor == true )
                        ColorConsole.WriteLine( msg, ConsoleColor.Gray );
                    else
                        ColorConsole.WriteLine( msg );
                } else {
                    if ( DontChangeColor == true )
                        Console.Write( msg, ConsoleColor.Gray );
                    else
                        Console.Write( msg );
                }

            Console.ReadKey( true );
            if ( ClearAfter ) {
                //Escape code to clear history outside of console buffer size, prevents some issues on modern systems, however if ansi escape not supported
                //it will just print the text, which is why I clear after words just incase. I dont want to test if they support ansi first, for a trivial reason.
                Console.Write( "\x1b[3J" ); Console.Clear();
            }
        }
    }
}
