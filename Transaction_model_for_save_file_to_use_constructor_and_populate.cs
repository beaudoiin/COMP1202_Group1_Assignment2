
using System.Text.Json.Serialization;

namespace Assignment2 {
    /// <summary>
    /// Defines each transaction the user makes. Has a Date, Category, Description and Amount.
    /// Logical manipulation handled by the pain program class.
    /// </summary>
    [Serializable] //needs to be before transaction class
    public class Transaction {
        public DateOnly Date {
            get; set;
        }
        /// <summary>
        /// Gets or sets the category of the transaction, which determines its classification for reporting and
        /// processing purposes.
        /// </summary>
        /// <remarks>This property allows for categorization of transactions, enabling better organization
        /// and analysis of financial data.</remarks>
        public TransactionCategory Category {
            get; set;
        }
        public decimal Amount {

            get; set;
        }
        /// <summary>
        /// This description is provided by the user and printed when viewing transactions.
        /// </summary>
        public string Description {
            get; set;
        }
        [JsonConstructor]
        public Transaction( DateOnly Date, decimal amount, string Description, TransactionCategory category = 0 ) {
            this.Date = Date;
            //Rounds the users inputed Amount to the nearest hundreth. May not be nesacary but allows users to put in fractional amounts.
            Amount = Math.Round( amount, 2 );
            this.Description = Description;
            this.Category = category;
        }
    }
}