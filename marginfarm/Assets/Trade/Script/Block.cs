using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;

namespace Blockchain
{
    public class Block : MonoBehaviour
    {
        public Block(BlockHeader blockHeader, string transactions)
        {
            this.blockHeader = blockHeader;
            this.transactions = transactions;
        }

        private int blockSize;
        private BlockHeader blockHeader;
        private int transactionCount;
        private string transactions;


        public string getBlockHash()
        {
            byte[] bytes = blockHeader.toByteArray();
            using (SHA256Managed hashstring = new SHA256Managed())
            {

                byte[] blockHash = hashstring.ComputeHash(bytes);
                blockHash = hashstring.ComputeHash(blockHash);

                return ByteArrayToString(blockHash);
            }
        }

        public string getBlocktransaction()
        {
            string tran = transactions;

            return tran.ToString();
        }

        public static string ByteArrayToString(byte[] bts)
        {
            StringBuilder strBld = new StringBuilder();
            foreach (byte bt in bts)
                strBld.AppendFormat("{0:X2}", bt);

            return strBld.ToString();
        }

    }

    public class BlockHeader
    {
        public BlockHeader(byte[] previousBlockHash, string transactions)
        {
            this.previousBlockHash = previousBlockHash;
            this.merkleRootHash = transactions.GetHashCode()+timestamp;
        }

        private byte[] previousBlockHash;
        private int merkleRootHash;
        private int timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        private static uint difficultyTarget = 2;
        private static int nonce = 0;


        public int ProofOfWorkCount()
        {
            using (SHA256Managed hashstring = new SHA256Managed())
            {
                byte[] bt;
                string sHash = string.Empty;
                while (sHash == string.Empty || sHash.Substring(0, (int)difficultyTarget) != ("").PadLeft((int)difficultyTarget, '0'))
                {
                    bt = Encoding.UTF8.GetBytes(merkleRootHash + nonce.ToString());
                    sHash = Block.ByteArrayToString(hashstring.ComputeHash(bt));
                    nonce++;
                }
                return nonce;
            }
        }


        public byte[] toByteArray()
        {
            string tmpStr = "";

            if (previousBlockHash != null)
            {
                tmpStr += Convert.ToBase64String(previousBlockHash);
            }
            tmpStr += merkleRootHash.ToString();
            return Encoding.UTF8.GetBytes(tmpStr);
        }

    }
}
