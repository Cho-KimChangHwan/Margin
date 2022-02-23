using System;
using System.Collections.Generic;
using System.Text;
using Blockchains;
using System.Diagnostics;

namespace BlockchainTest
{
    class Program
    {
        List<Blockchain> blockchain = new List<Blockchain>();
        static string savetran = "";
        static string genesishash = "";
        static string newblockhash = "";
        
        static void Main(string[] args)
        {
            int k = 5;
            string transactions = "Jihwan";
            
            //GenesisBlock create
            BlockHeader blockheader = new BlockHeader(null, transactions);
            Blockchain genesisBlock = new Blockchain(blockheader, transactions);
            
            //hash save
            genesishash = genesisBlock.getBlockHash();

            //New Block mining
            Blockchain previousBlock = genesisBlock;
            for(int i = 0; i< k; i++)
            {
                previousBlock = miner(transactions,i+1);
            }
        
        }

        static Blockchain miner(string transactions,int index){
            
            BlockHeader secondBlockheader = new BlockHeader(Encoding.UTF8.GetBytes(newblockhash), transactions);
            Blockchain nextBlock = new Blockchain(secondBlockheader, transactions);
        
            int count = secondBlockheader.ProofOfWorkCount();

            Blockchain previousBlock = nextBlock;

            newblockhash = previousBlock.getBlockHash();
            savetran = previousBlock.getBlocktransaction();

            return previousBlock;    
        }

    }
}