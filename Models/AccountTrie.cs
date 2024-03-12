﻿using PsychTestsMilitary.Services.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace PsychTestsMilitary.Models
{
    internal class TrieNode
    {
        public char chr;
        public Dictionary<char, TrieNode> children;
        public bool isEndOfWord;
        public Account acc;

        public TrieNode(char symbol)
        {
            chr = symbol;
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
        }
    }

    public class AccountTrie
    {
        private TrieNode root;

        public AccountTrie()
        {
            root = new TrieNode('/');
            HandleAccountsDb();
        }

        private void HandleAccountsDb()
        {
            List<Account> accounts = new List<Account>();

            using (AccountContext context = new AccountContext())
            {
                accounts = context.Accounts.ToList();
            }

            foreach (Account account in accounts)
            {
                this.Add(ConcatDBFields(new string[] {account.Surname, " ", account.Name, " ", account.FName, " (",
                                                        account.Birthday,")"}), account);
            }
        }

        public Dictionary<Account, string> Autocomplete(string prefix)
        {
            if (prefix.Length < 3)
                return null;

            Dictionary<Account, string> suggestions = new Dictionary<Account, string>();
            TrieNode lastNode = FindLastNodeOfPrefix(prefix);

            if (lastNode != null)
                AutocompleteRec(lastNode, prefix, suggestions);

            return suggestions;
        }

        private TrieNode FindLastNodeOfPrefix(string prefix)
        {
            TrieNode current = root;

            foreach (char c in prefix)
            {
                if (!current.children.ContainsKey(c))
                    return null;

                current = current.children[c];
            }

            return current;
        }

        private void AutocompleteRec(TrieNode node, string currentPrefix, Dictionary<Account, string> suggestions)
        {
            if (node.isEndOfWord)
            {
                suggestions.Add(node.acc, currentPrefix);
            }

            foreach (var child in node.children)
                AutocompleteRec(child.Value, currentPrefix + child.Key, suggestions);
        }

        private string ConcatDBFields(string[] str)
        {
            string result = null;

            for (int i = 0; i < str.Length; i++)
                result += str[i];

            return result;
        }

        private void Add(string str, Account account)
        {
            TrieNode currentNode = root;

            foreach (char c in str)
            {
                if (!currentNode.children.ContainsKey(c))
                    currentNode.children[c] = new TrieNode(c);

                currentNode = currentNode.children[c];
            }

            currentNode.isEndOfWord = true;
            currentNode.acc = account;
        }
    }
}
