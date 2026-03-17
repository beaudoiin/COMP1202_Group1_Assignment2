namespace Assignment2 {
    internal class Enumerators {
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

        /// <summary>
        /// Specify which option the user can choose for searching transactions.
        /// </summary>
        enum SearchType {
            DateRange,
            PriceRange,
            Category
        }

        /// <summary>
        /// Holds each transaction type and is crucial for both formatting and logic.
        /// You can add onto this list other transasctions, however if you increase past the Console WindowHeight you
        /// may need to adjust the code to print in columns or other features. This is a decent standard list.
        /// Income needs to be 0, it seperates it from transactions.
        /// </summary>
        public enum TransactionCategory {
            Income = 0, //Keep the 0 incase you move this it will always be first in the list.
            Housing,
            Groceries,
            Transportation,
            Utilities,
            Restaurants,
            Insurance,
            Debt,
            Entertainment,
            Healthcare,
            Transfers,
            Fees,
            Other
        }
    }
}
