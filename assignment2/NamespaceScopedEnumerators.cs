namespace Assignment2 {
    //Used for storing the colors for specificstring types. You use this to set the console color for consistancy, or use a custom
    //method such as ColorConsole (user defined) where the message and color is passed. This way the main program is not riddled 
    //with many lines of ccolor formatting.
    // Alternative is to store ansi escape codes for coloring, but this means the app needs to test of the terminal supports that feature or not. The safest
    // bet is to use ConsoleColor.
    enum ColorGroup {
        DefaultText,
        Warning,
        Error,
        Instructions,
        MenusHeadings,
        MenusListItems,
        Success,
        InputStyleA
    }
    /// <summary>
    /// Enum for holding the Keys for the language dictionary.
    /// The purpose is to store all strings in one place for consistancy and if implemented, translation
    /// </summary>
    enum MessageEnum {
        #region >>> // System
        System_AnyKeyToContinue,
        System_AnyKeyToExit,
        #endregion
        #region >>> // System instructions
        SystemInstructions_AnyKeyToAck,
        SystemInstructions_EscapeOrBackspace,
        SystemInstructions_TypeToExitOrAbort,
        SystemInstructions_InputYearForSummary,
        SystemInstructions_InputMonthForSummary,
        SystemInstructions_Abort,
        SystemInstructions_InputIncomeAmount,
        SystemInstructions_InputTransDescription,
        SystemInstructions_EnterDate,
        SystemInstructions_EnterEmail,
        SystemInstructions_PressToExit, // Label for instructing to exit program

        #endregion
        #region >>> // Warning
        Warning_BadDate,
        Warning_BadInput,
        Warning_DateFormat,
        Warning_EmptyOrSpaces,
        Warning_BadAmountNoZero,
        Warning_InvalidYearOld,
        Warning_InvalidYearNew,
        Warning_InvalidMonth,
        Warning_YearTooBig,
        Warning_YearInFuture,
        Warning_Exception_FileNotAuthorized,
        Warning_Exception_ArgumentException,
        Warning_Exception_FileNotFound,
        Warning_Exception_DirectoriesNotFound,
        Warning_Exception_FileNull,
        Warning_Exception_General,

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
        //Label_SearchAborted, //may not be in use
        Label_Options,
        Label_Date,
        Label_All,
        Label_Years,
        Label_Amount,
        Label_Description,
        Label_Instructions,
        //Label_PageAbreviated, // Only used if displaying lists with pages like pg 1/5. important when other languages impliment differently
        Label_FileName,
        Label_FileFound,
        #endregion
        #region >>> // General menu options
        Menu_Return, //this is for any menu that says something like "Return to menu"
        Menu_HeaderOuterDecor,
        #endregion
        #region >>> // Main Menu options
        MainMenu_Header,
        MainMenu_Load,
        MainMenu_Save,
        MainMenu_Options,
        //Add more for this specific program such as "Add Students"
        #endregion
        #region >>> // Menu Options
        //Options_ChangLang, //Only if your deciding to impliment multi-lingual support
        //Options_AutoSave, //only if auto save is an option
        //Add any option labels here
        #endregion
        //Below is only if implimenting encrypted file protection with entering a secure password.
        #region >> // Get Pwd
        /*
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
        */
        #endregion
        //Below is only if implimeniting multi-lingual support
        #region >>> // ChooseLang
        /*
        ChooseLang_Header,
        ChooseLang_RevertingToEng,
        ChooseLang_LangApplied,
        */

        #endregion
        //This really depends on how you impliment the loading.
        #region >> //LoadFile
        //LoadFile_AbordTransactionFileFound, //This is found in load file after cooldown when user escapes
        //LoadFile_TooManyIncorrect,
        //LoadFile_EnterPwForTransactionFile,
        //LoadFile_IncorrectPwCoolDown,
        //LoadFile_ToAbortStartNoTrans,
        //LoadFile_NoTransactionsFound,
        //LoadFile_ConfirmLoadingBudgetFileOnly,
        //LoadFile_NoFileFound,
        //LoadFile_BudgetFileFound,
        //LoadFile_ConfrimLoadBudgetFile,
        //LoadFile_NoTransOrBudgetFileFound,
        //LoadFile_PwIncorrect,
        //LoadFile_ForOtherOptionsSampleData,
        //LoadFile_ConfrimTryAnotherPw,
        //LoadFile_TooManyWrongPwAttempts,
        //LoadFile_CooldownForNextAttempt,
        #endregion
        //Below is if we allow sample data to be loaded for the professor
        #region >> // SampleTransaction
        //Sample_Header,
        //Sample_Loaded,
        #endregion

        //Sections may include course names and descriptions, and other varius rules for email format and other such rules.
        //Basically add as needed
    }
    //Remove if not serching by different filters
    ///// <summary>
    ///// Specify which option the user can choose for searching transactions.
    ///// </summary>
    //enum SearchType {
    //    DateRange,
    //    PriceRange,
    //    Category
    //}
}
