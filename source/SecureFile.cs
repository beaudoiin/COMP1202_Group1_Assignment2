
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace assignment2 {
    /// <summary>
    /// Provides methods for securely loading and saving files, with optional encryption using a password.
    /// </summary>
    /// <remarks>The Load method reads a file from the specified path, decrypting it if a password is
    /// provided. The Save method writes data to a file, encrypting it if a password is supplied. Both methods handle
    /// JSON serialization and deserialization of the data.</remarks>
    public static class SecureFile {
        /// <summary>
        /// Loads an object of type T from the specified file path, optionally decrypting the file using a provided
        /// password.
        /// </summary>
        /// <remarks>If a password is provided, the file is expected to be encrypted and will be decrypted
        /// using the password. If decryption fails due to an incorrect password or file tampering, the method returns
        /// the default value for type T and sets passwordCorrect to <see langword="false"/>. The object is deserialized
        /// from JSON after decryption or direct reading.</remarks>
        /// <typeparam name="T">The type of the object to be loaded from the file.</typeparam>
        /// <param name="path">The path to the file containing the serialized object. The file must exist; otherwise, the method returns
        /// the default value for type T.</param>
        /// <param name="passwordCorrect">A reference parameter that is set to <see langword="true"/> if the password is correct and the file is
        /// successfully decrypted; otherwise, <see langword="false"/>.</param>
        /// <param name="password">An optional password used to decrypt the file. If not provided, the file is loaded without decryption.</param>
        /// <returns>An instance of type T loaded from the file, or the default value of T if the file does not exist or
        /// decryption fails.</returns>
        public static T? Load<T>( string path, ref bool passwordCorrect, string? password = null ) {
            byte [ ] plaintext;
            passwordCorrect = false;
            if ( !File.Exists( path ) )
                return default;
            using var fs = new FileStream( path, FileMode.Open );
            if ( password is not null ) {
                byte [ ] salt = new byte [ 16 ];
                fs.ReadExactly( salt );
                byte [ ] key = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    100_000,
                    HashAlgorithmName.SHA256,
                    32 );
                byte [ ] nonce = new byte [ 12 ];
                fs.ReadExactly( nonce );
                byte [ ] tag = new byte [ 16 ];
                fs.ReadExactly( tag );
                byte [ ] ciphertext = new byte [ fs.Length - 16 - 12 - 16 ];
                fs.ReadExactly( ciphertext );
                plaintext = new byte [ ciphertext.Length ];
                try {
                    using var aes = new AesGcm( key );
                    aes.Decrypt( nonce, ciphertext, tag, plaintext );
                }
                catch ( CryptographicException ) {
                    return default; // Wrong password or tampered file
                }
            } else {
                plaintext = new byte [ fs.Length ];
                fs.ReadExactly( plaintext );

            }
            string json = Encoding.UTF8.GetString( plaintext );
            passwordCorrect = true;
            return JsonSerializer.Deserialize<T>( json );
        }

        /// <summary>
        /// Saves the specified data to a file in JSON format. If a password is provided, the data is encrypted using AES
        /// before being written to the file.
        /// </summary>
        /// <remarks>When a password is provided, the method generates a random salt and nonce for
        /// encryption. The encrypted output includes the salt, nonce, authentication tag, and ciphertext, written
        /// sequentially to the file. If no password is specified, the data is saved as plain JSON. The caller is
        /// responsible for ensuring the file path is accessible and for managing the password securely.</remarks>
        /// <typeparam name="T">The type of the data to serialize and save.</typeparam>
        /// <param name="path">The file path where the data will be saved. Must be a valid and accessible location.</param>
        /// <param name="data">The data to serialize and save. Can be any object that is supported by JSON serialization.</param>
        /// <param name="password">An optional password used to encrypt the data. If specified, the data is encrypted using AES; otherwise, it
        /// is saved in plain JSON format.</param>
        public static void Save<T>( string path, T data, string? password = null ) {
            string json = JsonSerializer.Serialize( data );
            byte [ ] plainBytes = Encoding.UTF8.GetBytes( json );
            //if the file is using AES use this
            if ( password is not null ) {
                byte [ ] salt = RandomNumberGenerator.GetBytes( 16 );
                byte [ ] key = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    100_000,
                    HashAlgorithmName.SHA256,
                    32 );
                byte [ ] nonce = RandomNumberGenerator.GetBytes( 12 );   // GCM standard
                byte [ ] ciphertext = new byte [ plainBytes.Length ];
                byte [ ] tag = new byte [ 16 ];
                using var aes = new AesGcm( key );
                aes.Encrypt( nonce, plainBytes, ciphertext, tag );
                using var fs = new FileStream( path, FileMode.Create );
                fs.Write( salt );
                fs.Write( nonce );
                fs.Write( tag );
                fs.Write( ciphertext );
            } else {
                using var fs = new FileStream( path, FileMode.Create );
                fs.Write( plainBytes );
            }
        }
    }

}
