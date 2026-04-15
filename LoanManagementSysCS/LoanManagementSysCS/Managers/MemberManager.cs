using System;
using System.Collections.Generic;

namespace LoanManagementSys.Managers
{
    internal class MemberManager
    {
        private List<Member> members = new List<Member>();

        public void Add(Member member)
        {
            members.Add(member);
        }

        public void Remove(int index)
        {
            if (CheckIndex(index))
                members.RemoveAt(index);
        }

        public Member Get(int index)
        {
            if (CheckIndex(index))
                return members[index];

            return null;
        }

        public int Count
        {
            get { return members.Count; }
        }

        private bool CheckIndex(int index)
        {
            return index >= 0 && index < members.Count;
        }

        public void AddTestMembers()
        {
            for (int i = 1; i <= 25; i++)
            {
                Add(new Member(i, $"Member{i}"));
            }
        }

        public string[] GetMemberInfoStrings()
        {
            if (members.Count == 0)
                return new string[] { "No members" };

            string[] arr = new string[members.Count];

            for (int i = 0; i < members.Count; i++)
                arr[i] = members[i].ToString();

            return arr;
        }
    }
}