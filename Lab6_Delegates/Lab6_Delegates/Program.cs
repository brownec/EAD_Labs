// Cliff Browne - X00014810
// EAD Lab6 - Delegates
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* A system is required which allows for different ciphers to be used to encrypt plaintext messages into ciphertext. 
 * Use a delegate to define a set of methods which take a plaintext message as input and return a ciphertext message. 
Implement two different ciphers which can be plugged and played via the delegate. 
 * The first cipher should be a simple Caeser cipher which shifts up every character in the plaintext by one character position. 
 * The second cipher should just reverse the plaintext to form the ciphertext.
 */

delegate string EncryptionDelegate(string plaintext);

class Cipher
    {
    // Simple Cesaer Cipher
    public static string Cipher1(String plaintext)
    {
        const int key = 1; // shifts the plaintext by 1 character
        StringBuilder ciphertext = new StringBuilder(plaintext);

        // Unicode MAX value is (2 ^ 16) - 1
        int wrap = (int)(char.MaxValue);

        // shift each character forward by a selected key amount
        for (int i = 0; i < ciphertext.Length; i++)
        {
            ciphertext[i] = (char) ((ciphertext[i] + key) % wrap);
        }
        return ciphertext.ToString();
    }

        // Test Class
        public static void Main()
        {
            Console.WriteLine("**********EAD Lab 6 - Delegates**********");
        }
    }
}
