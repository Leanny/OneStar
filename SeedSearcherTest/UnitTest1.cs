using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedSearcherGui;

namespace SeedSearcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Fixed1_6_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 26, 16, 6, 10, 3, 1, 1, 19, 2, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(1, 31, 9, 3, 23, 22, 1, 0, 19, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 2, 5, 26, 19, 31, 1, 1, 16, 4, 0, 0, false, false);
            int[] target = { 26, 16, 6, 10, 3, 11 };
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(24, 17, 29, 31, 19, 4, 1, 1, 5, 5, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(11, 15, 25, 22, 6, 31, 1, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(29, 18, 31, 30, 19, 29, 1, 1, 6, 1, 0, 0, false, false);
            int[] target = { 24, 17, 29, 19, 4, 31 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 6, 21, 20, 31, 4, 1, 1, 1, 2, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(31, 16, 3, 13, 8, 11, 1, 0, 6, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 16, 23, 21, 1, 27, 1, 0, 9, 0, 0, 0, false, false);
            int[] target = { 7, 6, 21, 20, 4, 7 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 8, 5, 18, 22, 27, 1, 1, 4, 0, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(30, 17, 22, 31, 0, 19, 1, 0, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 25, 31, 29, 25, 15, 1, 1, 0, 2, 0, 0, false, false);
            int[] target = { 8, 5, 18, 22, 27, 29 };
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfbde94815ae686b5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 4, 7, 14, 31, 14, 1, 1, 3, 0, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(22, 31, 4, 20, 24, 8, 1, 1, 9, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 31, 25, 5, 2, 17, 1, 0, 2, 2, 0, 0, false, false);
            int[] target = { 20, 4, 7, 14, 14, 27 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 16, 31, 13, 31, 20, 1, 0, 8, 3, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(31, 13, 21, 3, 12, 2, 1, 0, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 25, 10, 27, 19, 1, 1, 22, 5, 0, 0, false, false);
            int[] target = { 20, 16, 31, 13, 20, 6 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x56c57c9f861283eeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(14, 19, 29, 31, 12, 7, 1, 0, 9, 0, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(8, 18, 31, 25, 1, 27, 1, 0, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 31, 17, 29, 26, 16, 1, 1, 21, 2, 0, 0, false, false);
            int[] target = { 14, 19, 29, 12, 7, 28 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x726bc1c2727c889ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(17, 20, 2, 31, 18, 24, 1, 0, 3, 5, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(10, 7, 4, 30, 2, 31, 1, 1, 22, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 2, 31, 3, 21, 1, 1, 0, 3, 1, 0, 0, false, false);
            int[] target = { 17, 20, 2, 18, 24, 30 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x13b9d7a98177a652ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(8, 8, 25, 31, 25, 28, 1, 1, 23, 3, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(26, 1, 9, 23, 21, 31, 1, 1, 10, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 0, 31, 28, 5, 20, 1, 1, 14, 1, 0, 0, false, false);
            int[] target = { 8, 8, 25, 25, 28, 5 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf96a9e219cd4b8f2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(24, 4, 31, 17, 19, 8, 1, 1, 5, 2, 0, 0, false, false, 2);
            searcher.RegisterPokemon2(22, 31, 1, 26, 20, 28, 1, 1, 6, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 19, 3, 9, 27, 31, 1, 0, 2, 0, 0, 0, false, false);
            int[] target = { 24, 4, 17, 19, 8, 3 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2aee4d78c82594a5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 24, 12, 13, 31, 27, 1, 0, 12, 0, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(8, 31, 17, 7, 22, 19, 1, 1, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 28, 23, 19, 6, 31, 1, 1, 16, 2, 0, 0, false, false);
            int[] target = { 20, 24, 12, 13, 27, 24 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f701fcc7031b7edul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 14, 3, 31, 10, 31, 1, 0, 6, 1, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(29, 31, 7, 10, 10, 10, 1, 0, 21, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 16, 6, 15, 30, 31, 1, 1, 19, 3, 0, 0, false, false);
            int[] target = { 25, 14, 3, 31, 10, 2 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x286af6a95a11b890ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 8, 18, 11, 15, 27, 1, 0, 6, 5, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(31, 26, 5, 30, 12, 9, 1, 0, 7, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 2, 14, 0, 20, 31, 1, 1, 13, 1, 0, 0, false, false);
            int[] target = { 8, 18, 11, 15, 27, 20 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xe1b27e774ba7d1d2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(24, 29, 26, 30, 31, 30, 1, 1, 0, 3, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(20, 11, 1, 30, 3, 31, 1, 0, 13, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 26, 31, 31, 10, 27, 1, 1, 19, 1, 0, 0, false, false);
            int[] target = { 24, 29, 26, 30, 30, 23 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x334dd445c9daa3bcul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 19, 31, 8, 31, 31, 1, 1, 22, 4, 0, 0, false, false, 2);
            searcher.RegisterPokemon2(15, 28, 21, 18, 7, 31, 1, 0, 22, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 21, 23, 31, 19, 13, 1, 1, 4, 2, 0, 0, false, false);
            int[] target = { 17, 19, 8, 31, 31, 9 };
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc77f0cf6d9541637ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 31, 29, 3, 6, 3, 1, 0, 23, 3, 0, 0, false, false, 1);
            searcher.RegisterPokemon2(18, 4, 31, 31, 31, 5, 1, 1, 22, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 6, 4, 24, 6, 1, 1, 14, 5, 0, 0, false, false);
            int[] target = { 18, 29, 3, 6, 3, 18 };
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x821ce3932db7830cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(15, 14, 30, 3, 31, 16, 1, 0, 18, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(30, 30, 19, 2, 2, 31, 1, 0, 6, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 26, 16, 27, 18, 27, 1, 0, 16, 3, 0, 0, false, false);
            int[] target = { 15, 14, 30, 3, 16, 2 };
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd97e2594f806755cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 7, 26, 7, 1, 31, 1, 0, 6, 0, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(31, 8, 4, 13, 6, 9, 1, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 31, 30, 22, 21, 31, 1, 1, 9, 2, 0, 0, false, false);
            int[] target = { 28, 7, 26, 7, 1, 24 };
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4d3b77e582afdc3bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 30, 9, 31, 10, 1, 1, 0, 9, 4, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(27, 9, 31, 17, 3, 29, 1, 0, 6, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 14, 25, 13, 31, 13, 1, 1, 16, 0, 0, 0, false, false);
            int[] target = { 7, 30, 9, 10, 1, 24 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x690631d596db0e5bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 11, 4, 21, 6, 2, 1, 0, 7, 1, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(24, 2, 13, 23, 21, 31, 1, 1, 23, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 10, 31, 2, 26, 15, 1, 0, 11, 3, 0, 0, false, false);
            int[] target = { 11, 4, 21, 6, 2, 4 };
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb59ffd2840b37d28ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_6_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(1, 1, 31, 21, 15, 31, 1, 0, 8, 2, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(21, 31, 28, 1, 31, 28, 1, 0, 4, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 30, 5, 12, 29, 31, 1, 0, 19, 4, 0, 0, false, false);
            int[] target = { 1, 1, 31, 21, 15, 12 };
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x15299cc85208cb6bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 16, 31, 6, 10, 3, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 11, 31, 31, 6, 19, 3, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            int[] target = { 16, 6, 10, 3, 11, 6 };
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 29, 31, 19, 4, 3, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 17, 29, 19, 4, 31, 10 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 19, 31, 31, 22, 3, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            int[] target = { 23, 22, 4, 14, 19, 22 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 31, 31, 17, 0, 30, 2, 0, 19, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 30, 6, 1, 3, 1, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 7, 19, 31, 9, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 31, 4, 5, 11, 31, 2, 1, 3, 2, 0, 0, false, false);
            int[] target = { 17, 17, 0, 30, 6, 1 };
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x84eaa04c62e02131ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 4, 7, 18, 31, 31, 2, 1, 16, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 15, 31, 16, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 8, 31, 11, 10, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 0, 0, false, false);
            int[] target = { 20, 4, 7, 18, 1, 15 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 18, 31, 19, 31, 10, 2, 0, 19, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 31, 31, 19, 31, 10, 3, 0, 19, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 3, 31, 31, 3, 11, 2, 0, 11, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 3, 31, 31, 31, 10, 2, 0, 6, 0, 0, 0, false, false);
            int[] target = { 17, 18, 19, 10, 8, 25 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd1b37d2f310fe105ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 3, 31, 31, 5, 31, 2, 1, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 2, 0, 0, false, false);
            int[] target = { 7, 3, 5, 31, 31, 24 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 15, 31, 10, 6, 2, 0, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 10, 31, 31, 6, 3, 0, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 8, 15, 31, 31, 29, 2, 1, 4, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 31, 14, 7, 13, 2, 1, 22, 4, 0, 0, false, false);
            int[] target = { 4, 15, 10, 6, 30, 26 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb9ef3bbafb7173bdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 7, 28, 31, 20, 31, 2, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 28, 20, 31, 31, 31, 3, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 31, 25, 1, 27, 2, 0, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 17, 29, 26, 16, 2, 1, 21, 2, 0, 0, false, false);
            int[] target = { 12, 7, 28, 20, 9, 24 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x726bc1c2727c889ful, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 3, 31, 31, 31, 10, 2, 0, 6, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 14, 31, 31, 31, 6, 3, 0, 21, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 2, 0, 0, false, false);
            int[] target = { 28, 3, 31, 10, 28, 14 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(30, 4, 11, 31, 31, 19, 2, 0, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 0, 31, 31, 31, 3, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 0, 0, false, false);
            int[] target = { 30, 4, 11, 19, 12, 13 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 27, 31, 25, 31, 2, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 28, 31, 3, 0, 16, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 10, 31, 6, 31, 28, 2, 1, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 31, 31, 9, 22, 28, 2, 0, 22, 3, 0, 0, false, false);
            int[] target = { 31, 27, 31, 25, 28, 22 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4836f1443738f67eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 3, 25, 22, 15, 31, 2, 1, 1, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 25, 22, 31, 15, 31, 3, 1, 1, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 16, 2, 31, 7, 2, 1, 7, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 24, 25, 15, 30, 31, 2, 1, 4, 2, 0, 0, false, false);
            int[] target = { 3, 25, 22, 15, 19, 2 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf8ed4fed77e072f7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 28, 17, 31, 12, 31, 2, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 17, 12, 31, 31, 31, 3, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 31, 0, 20, 18, 31, 2, 0, 13, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 28, 31, 31, 12, 20, 2, 0, 10, 4, 0, 0, false, false);
            int[] target = { 12, 28, 17, 12, 13, 16 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x71376ce6d12b5dd1ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 31, 31, 13, 31, 14, 2, 0, 23, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 14, 28, 31, 3, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 21, 16, 31, 24, 2, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 23, 31, 5, 3, 31, 2, 0, 1, 5, 0, 0, false, false);
            int[] target = { 18, 13, 31, 14, 28, 22 };
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x49f5a6a9c5f30364ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 24, 15, 15, 31, 12, 2, 0, 22, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 9, 3, 4, 31, 31, 3, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(4, 31, 7, 7, 1, 31, 2, 1, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 12, 31, 14, 24, 2, 0, 10, 2, 0, 0, false, false);
            int[] target = { 24, 15, 15, 12, 20, 24 };
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1a0a569824932885ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 28, 30, 24, 31, 11, 2, 1, 2, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 2, 3, 1, 23, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 0, 31, 14, 30, 2, 0, 19, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 13, 31, 27, 25, 2, 0, 4, 1, 0, 0, false, false);
            int[] target = { 28, 30, 24, 11, 21, 14 };
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf727197a69104a7cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 26, 26, 25, 31, 2, 0, 2, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 25, 24, 31, 3, 0, 24, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 17, 31, 1, 16, 2, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 12, 2, 23, 9, 2, 0, 24, 1, 0, 0, false, false);
            int[] target = { 25, 26, 26, 25, 24, 24 };
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x126865c9fb2b291eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 14, 13, 7, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 7, 27, 3, 31, 3, 0, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 12, 17, 31, 19, 2, 0, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 14, 31, 30, 30, 30, 2, 0, 15, 1, 0, 0, false, false);
            int[] target = { 31, 14, 13, 7, 27, 3 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x26de85077fa1dbeeul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(9, 20, 27, 31, 26, 31, 2, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 27, 31, 26, 31, 3, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 11, 31, 29, 2, 2, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 30, 31, 22, 2, 1, 18, 3, 0, 0, false, false);
            int[] target = { 9, 20, 27, 26, 17, 11 };
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xae5dc249ee1197b4ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 10, 31, 27, 24, 31, 2, 0, 18, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 31, 27, 24, 31, 3, 0, 18, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 31, 19, 28, 22, 31, 2, 1, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 18, 18, 2, 2, 0, 22, 4, 0, 0, false, false);
            int[] target = { 25, 10, 27, 24, 30, 3 };
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xdca13ba8f1fef023ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 28, 13, 31, 27, 17, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 13, 27, 31, 31, 17, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 31, 29, 2, 25, 2, 0, 14, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 31, 27, 31, 15, 27, 2, 0, 17, 0, 0, 0, false, false);
            int[] target = { 28, 13, 27, 17, 13, 7 };
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x32ab7d1ba5157c03ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 12, 31, 30, 21, 2, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 31, 21, 31, 2, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 31, 10, 12, 31, 22, 2, 1, 3, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 13, 28, 31, 31, 12, 2, 1, 20, 0, 0, 0, false, false);
            int[] target = { 12, 30, 21, 2, 9, 17 };
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5c10ffcb9decd7b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 20, 5, 1, 31, 29, 2, 1, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 29, 7, 31, 31, 3, 0, 11, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 14, 22, 31, 21, 8, 2, 1, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 9, 9, 2, 31, 2, 1, 0, 0, 0, 0, false, false);
            int[] target = { 20, 5, 1, 29, 7, 30 };
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x62dc05e6dfe40c4bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 4, 19, 9, 14, 2, 0, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 9, 31, 14, 3, 0, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 28, 31, 5, 31, 11, 2, 0, 14, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 11, 31, 20, 23, 18, 2, 1, 7, 1, 0, 0, false, false);
            int[] target = { 4, 19, 9, 14, 6, 27 };
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x67de866ca3b4057aul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(27, 31, 31, 6, 18, 4, 2, 0, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(6, 31, 31, 31, 18, 4, 3, 0, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 7, 31, 31, 3, 26, 2, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 13, 31, 13, 22, 27, 2, 1, 22, 4, 0, 0, false, false);
            int[] target = { 27, 6, 18, 4, 4, 20 };
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf3af363f0f3c21e5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 31, 1, 8, 17, 31, 2, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 31, 8, 17, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 2, 31, 0, 3, 22, 2, 0, 18, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 18, 31, 31, 0, 11, 2, 0, 16, 4, 0, 0, false, false);
            int[] target = { 28, 1, 8, 17, 21, 6 };
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfa680705fef93ef7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 20, 10, 29, 30, 2, 1, 2, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 10, 29, 31, 30, 3, 1, 2, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 24, 16, 31, 3, 19, 2, 0, 21, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 31, 23, 21, 1, 31, 2, 0, 12, 4, 0, 0, false, false);
            int[] target = { 20, 10, 29, 30, 25, 8 };
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x327499d6a1f87dfbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(5, 31, 31, 26, 19, 31, 3, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 31, 20, 31, 4, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            int[] target = { 5, 26, 19, 15, 20, 16 };
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87e8145f67d83f11ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 29, 31, 19, 4, 3, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 31, 4, 31, 4, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 29, 19, 4, 31, 10, 5 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(22, 31, 6, 31, 1, 31, 3, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 22, 31, 15, 31, 4, 1, 4, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 3, 0, 31, 12, 2, 0, 2, 4, 0, 0, false, false);
            int[] target = { 22, 6, 1, 9, 31, 8 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8d2d7749ad1313c7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 11, 31, 31, 6, 19, 3, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 4, 8, 4, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            int[] target = { 11, 6, 19, 18, 23, 0 };
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(14, 31, 19, 31, 31, 22, 3, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 5, 31, 31, 31, 4, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            int[] target = { 14, 19, 22, 7, 21, 20 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(22, 25, 31, 31, 31, 5, 3, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(5, 31, 31, 31, 31, 15, 4, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 31, 9, 0, 5, 31, 2, 0, 6, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 25, 15, 22, 31, 31, 2, 0, 14, 3, 0, 0, false, false);
            int[] target = { 22, 25, 5, 15, 21, 25 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f40a2fb3ec1f888ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 3, 28, 31, 1, 31, 3, 1, 19, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 3, 31, 31, 31, 4, 0, 19, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 10, 31, 31, 17, 3, 2, 1, 9, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(0, 1, 17, 31, 31, 0, 2, 0, 14, 1, 0, 0, false, false);
            int[] target = { 3, 28, 1, 3, 14, 19 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x15158ba914eb52d8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(1, 15, 31, 16, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 16, 31, 31, 4, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 8, 31, 11, 10, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 0, 0, false, false);
            int[] target = { 1, 15, 16, 21, 20, 29 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 31, 31, 2, 31, 4, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 2, 0, 0, false, false);
            int[] target = { 31, 31, 24, 17, 2, 0 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 31, 22, 31, 28, 31, 3, 0, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(22, 31, 28, 31, 31, 31, 4, 0, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 31, 31, 2, 0, 12, 2, 1, 12, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 17, 8, 23, 31, 31, 2, 1, 11, 0, 0, 0, false, false);
            int[] target = { 20, 22, 28, 24, 30, 17 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xda1db3506d655553ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 19, 31, 14, 31, 25, 3, 1, 20, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 14, 31, 31, 31, 25, 4, 1, 20, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 9, 31, 3, 31, 3, 2, 1, 11, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 6, 15, 21, 16, 2, 0, 17, 4, 0, 0, false, false);
            int[] target = { 19, 14, 25, 9, 30, 30 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3a2a4a70e6a53651ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 9, 25, 31, 31, 12, 3, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 31, 12, 4, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(3, 4, 31, 31, 2, 24, 2, 1, 6, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 10, 31, 30, 13, 8, 2, 1, 13, 5, 0, 0, false, false);
            int[] target = { 9, 25, 12, 28, 6, 22 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x56cc20e375d566eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 14, 31, 31, 31, 6, 3, 0, 21, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 8, 31, 31, 31, 31, 4, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 2, 0, 0, false, false);
            int[] target = { 28, 14, 6, 12, 31, 21 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 31, 31, 31, 20, 3, 0, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 31, 15, 4, 1, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 4, 31, 8, 15, 2, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 30, 31, 31, 29, 31, 2, 0, 24, 2, 0, 0, false, false);
            int[] target = { 4, 31, 20, 26, 26, 15 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9895217dee60a5f5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 13, 16, 31, 31, 19, 3, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 16, 19, 31, 31, 31, 4, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 12, 31, 31, 28, 25, 2, 1, 19, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 1, 4, 31, 18, 2, 1, 11, 4, 0, 0, false, false);
            int[] target = { 13, 16, 19, 27, 10, 31 };
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x55ee358bb3c4d049ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(14, 31, 0, 31, 31, 31, 3, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 31, 4, 1, 10, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 0, 0, false, false);
            int[] target = { 14, 31, 0, 21, 14, 1 };
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 21, 1, 31, 31, 31, 3, 0, 12, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(21, 31, 1, 31, 31, 31, 4, 0, 12, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 31, 15, 18, 31, 22, 2, 1, 18, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 15, 21, 24, 10, 31, 2, 0, 7, 4, 0, 0, false, false);
            int[] target = { 25, 21, 1, 24, 18, 12 };
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x43ff8b09ac6578b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(28, 31, 31, 2, 31, 10, 3, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(27, 31, 31, 31, 31, 2, 4, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 1, 10, 7, 31, 2, 1, 12, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(5, 12, 26, 31, 31, 1, 2, 0, 0, 5, 0, 0, false, false);
            int[] target = { 28, 2, 10, 6, 3, 27 };
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb1ade62968e5fef0ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(26, 31, 31, 31, 27, 7, 3, 0, 7, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 28, 31, 4, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(25, 26, 15, 31, 7, 31, 2, 0, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 14, 20, 5, 31, 2, 0, 21, 4, 0, 0, false, false);
            int[] target = { 26, 27, 7, 30, 10, 29 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb5841ab98fb62b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 26, 31, 31, 5, 16, 3, 1, 21, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 16, 31, 31, 9, 31, 4, 0, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 27, 31, 19, 3, 31, 2, 0, 13, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 12, 31, 31, 9, 19, 2, 1, 4, 0, 0, 0, false, false);
            int[] target = { 26, 5, 16, 9, 10, 21 };
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc7e13f6dda9e9a35ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(30, 31, 31, 31, 28, 11, 3, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 31, 31, 31, 7, 4, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 31, 31, 3, 31, 7, 2, 0, 16, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 3, 31, 28, 31, 0, 2, 0, 18, 2, 0, 0, false, false);
            int[] target = { 30, 28, 11, 7, 3, 30 };
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x61f4917777c91de5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 31, 31, 31, 14, 19, 3, 0, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(23, 31, 31, 31, 31, 1, 4, 0, 3, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 31, 31, 23, 4, 20, 2, 0, 23, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 17, 19, 21, 31, 2, 1, 11, 1, 0, 0, false, false);
            int[] target = { 19, 14, 19, 28, 23, 1 };
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2b10bbf5652f4974ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 31, 19, 31, 24, 31, 3, 0, 13, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 18, 31, 2, 31, 4, 1, 10, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 11, 11, 20, 11, 31, 2, 1, 6, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 7, 31, 13, 23, 2, 1, 1, 4, 0, 0, false, false);
            int[] target = { 7, 19, 24, 18, 2, 13 };
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x51458478591bd7bdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 9, 3, 4, 31, 31, 3, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 3, 4, 31, 31, 4, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(4, 31, 7, 7, 1, 31, 2, 1, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 12, 31, 14, 24, 2, 0, 10, 2, 0, 0, false, false);
            int[] target = { 9, 3, 4, 30, 7, 11 };
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1a0a569824932885ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 31, 31, 10, 31, 6, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 31, 31, 31, 31, 0, 4, 0, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 9, 4, 15, 31, 0, 2, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 1, 2, 16, 31, 31, 2, 0, 5, 4, 0, 0, false, false);
            int[] target = { 7, 10, 6, 25, 25, 19 };
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x800c22c48d686b03ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 15, 7, 14, 31, 31, 3, 0, 0, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 0, 31, 31, 4, 1, 16, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 15, 18, 14, 31, 31, 2, 0, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 24, 28, 16, 11, 31, 2, 0, 10, 1, 0, 0, false, false);
            int[] target = { 15, 7, 14, 20, 18, 27 };
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87ff9cce51fe7040ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 25, 31, 31, 20, 13, 3, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 20, 13, 4, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(10, 31, 31, 12, 17, 29, 2, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 31, 13, 27, 25, 2, 1, 12, 2, 0, 0, false, false);
            int[] target = { 25, 20, 13, 1, 10, 18 };
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x964f7901de273897ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 3, 30, 21, 31, 31, 3, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 21, 31, 31, 31, 4, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 24, 4, 2, 31, 31, 2, 0, 6, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 9, 8, 31, 14, 31, 2, 1, 23, 5, 0, 0, false, false);
            int[] target = { 3, 30, 21, 14, 12, 30 };
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x66a005ecf23cec50ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation28()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(11, 18, 31, 7, 31, 31, 3, 1, 3, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 7, 31, 31, 31, 31, 4, 1, 3, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 31, 2, 7, 27, 31, 2, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(12, 31, 0, 31, 9, 5, 2, 0, 9, 4, 0, 0, false, false);
            int[] target = { 11, 18, 7, 25, 1, 31 };
            var res = searcher.Calculate(28, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xbee8bf3b99da2d8dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation29()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(15, 31, 31, 29, 31, 28, 3, 0, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 31, 30, 31, 31, 4, 1, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 21, 31, 10, 22, 2, 1, 14, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 18, 13, 17, 29, 2, 1, 14, 4, 0, 0, false, false);
            int[] target = { 15, 29, 28, 30, 23, 1 };
            var res = searcher.Calculate(29, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa07637165382c68bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation30()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 20, 31, 26, 30, 3, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 26, 31, 31, 30, 4, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 13, 31, 31, 22, 6, 2, 0, 14, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 29, 31, 5, 26, 31, 2, 1, 15, 1, 0, 0, false, false);
            int[] target = { 20, 26, 30, 16, 5, 2 };
            var res = searcher.Calculate(30, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x10cf4c25b6bc48b8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation31()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 24, 31, 31, 31, 23, 3, 1, 3, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(24, 23, 31, 31, 31, 31, 4, 1, 3, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 4, 31, 31, 0, 21, 2, 0, 4, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 5, 31, 24, 19, 23, 2, 1, 15, 0, 0, 0, false, false);
            int[] target = { 21, 24, 23, 25, 3, 3 };
            var res = searcher.Calculate(31, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xca90fb7f5ef5a22dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation32()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(22, 31, 31, 31, 17, 28, 3, 1, 3, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 31, 31, 31, 25, 4, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 2, 31, 2, 31, 10, 2, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 31, 14, 16, 7, 31, 2, 1, 7, 1, 0, 0, false, false);
            int[] target = { 22, 17, 28, 11, 25, 28 };
            var res = searcher.Calculate(32, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x703d23b2c9dfbce0ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation33()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 30, 31, 8, 18, 31, 3, 0, 12, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 12, 29, 31, 4, 0, 11, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 31, 23, 31, 16, 11, 2, 1, 4, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 31, 11, 8, 4, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 30, 8, 18, 14, 23, 25 };
            var res = searcher.Calculate(33, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa40e07dc65799cb8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation34()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 31, 22, 23, 31, 31, 3, 1, 9, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 24, 31, 31, 31, 4, 0, 15, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 31, 5, 31, 10, 19, 2, 0, 6, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 30, 31, 17, 3, 31, 2, 1, 2, 0, 0, 0, false, false);
            int[] target = { 12, 22, 23, 21, 20, 9 };
            var res = searcher.Calculate(34, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd590d450fba73ccful, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation35()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 19, 31, 27, 20, 31, 3, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 31, 20, 31, 4, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(6, 31, 17, 9, 31, 13, 2, 1, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 31, 0, 29, 28, 31, 2, 1, 21, 4, 0, 0, false, false);
            int[] target = { 19, 27, 20, 3, 2, 29 };
            var res = searcher.Calculate(35, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf892b015089d6ccdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation36()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 9, 31, 0, 31, 31, 3, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(0, 31, 31, 15, 31, 31, 4, 0, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 17, 10, 31, 31, 7, 2, 1, 15, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 0, 31, 17, 23, 31, 2, 1, 24, 4, 0, 0, false, false);
            int[] target = { 21, 9, 0, 15, 20, 15 };
            var res = searcher.Calculate(36, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc7bc46574b6a4b51ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_6_Deviation37()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 13, 25, 30, 31, 31, 3, 0, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 30, 18, 31, 31, 4, 1, 8, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 28, 17, 31, 21, 31, 2, 1, 13, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(23, 21, 28, 31, 31, 26, 2, 0, 20, 3, 0, 0, false, false);
            int[] target = { 13, 25, 30, 18, 17, 1 };
            var res = searcher.Calculate(37, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf101cc99d97677fcul, res[0] - 0x7817eba09827c0ef);
        }

        [TestMethod]
        public void Test_Fixed2_5_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 16, 31, 6, 10, 3, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 11, 31, 31, 6, 19, 3, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            int[] target = { 16, 6, 10, 3, 11, 6 };
            target[5] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 29, 31, 19, 4, 3, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 17, 29, 19, 4, 31, 10 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 19, 31, 31, 22, 3, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            int[] target = { 23, 22, 4, 14, 19, 22 };
            target[5] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 31, 31, 17, 0, 30, 2, 0, 19, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 30, 6, 1, 3, 1, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 7, 19, 31, 9, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 31, 4, 5, 11, 31, 2, 1, 3, 2, 0, 0, false, false);
            int[] target = { 17, 17, 0, 30, 6, 1 };
            target[5] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x84eaa04c62e02131ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 4, 7, 18, 31, 31, 2, 1, 16, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 15, 31, 16, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 8, 31, 11, 10, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 0, 0, false, false);
            int[] target = { 20, 4, 7, 18, 1, 15 };
            target[5] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 18, 31, 19, 31, 10, 2, 0, 19, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 31, 31, 19, 31, 10, 3, 0, 19, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 3, 31, 31, 3, 11, 2, 0, 11, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 3, 31, 31, 31, 10, 2, 0, 6, 0, 0, 0, false, false);
            int[] target = { 17, 18, 19, 10, 8, 25 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd1b37d2f310fe105ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 3, 31, 31, 5, 31, 2, 1, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 2, 0, 0, false, false);
            int[] target = { 7, 3, 5, 31, 31, 24 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 15, 31, 10, 6, 2, 0, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 10, 31, 31, 6, 3, 0, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 8, 15, 31, 31, 29, 2, 1, 4, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 31, 14, 7, 13, 2, 1, 22, 4, 0, 0, false, false);
            int[] target = { 4, 15, 10, 6, 30, 26 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb9ef3bbafb7173bdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 7, 28, 31, 20, 31, 2, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 28, 20, 31, 31, 31, 3, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 31, 25, 1, 27, 2, 0, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 17, 29, 26, 16, 2, 1, 21, 2, 0, 0, false, false);
            int[] target = { 12, 7, 28, 20, 9, 24 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x726bc1c2727c889ful, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 3, 31, 31, 31, 10, 2, 0, 6, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 14, 31, 31, 31, 6, 3, 0, 21, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 2, 0, 0, false, false);
            int[] target = { 28, 3, 31, 10, 28, 14 };
            target[5] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(30, 4, 11, 31, 31, 19, 2, 0, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 0, 31, 31, 31, 3, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 0, 0, false, false);
            int[] target = { 30, 4, 11, 19, 12, 13 };
            target[5] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 27, 31, 25, 31, 2, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 28, 31, 3, 0, 16, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 10, 31, 6, 31, 28, 2, 1, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 31, 31, 9, 22, 28, 2, 0, 22, 3, 0, 0, false, false);
            int[] target = { 31, 27, 31, 25, 28, 22 };
            target[5] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4836f1443738f67eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 3, 25, 22, 15, 31, 2, 1, 1, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 25, 22, 31, 15, 31, 3, 1, 1, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 16, 2, 31, 7, 2, 1, 7, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 24, 25, 15, 30, 31, 2, 1, 4, 2, 0, 0, false, false);
            int[] target = { 3, 25, 22, 15, 19, 2 };
            target[5] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf8ed4fed77e072f7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 28, 17, 31, 12, 31, 2, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 17, 12, 31, 31, 31, 3, 1, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 31, 0, 20, 18, 31, 2, 0, 13, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 28, 31, 31, 12, 20, 2, 0, 10, 4, 0, 0, false, false);
            int[] target = { 12, 28, 17, 12, 13, 16 };
            target[5] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x71376ce6d12b5dd1ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 31, 31, 13, 31, 14, 2, 0, 23, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 14, 28, 31, 3, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 21, 16, 31, 24, 2, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 23, 31, 5, 3, 31, 2, 0, 1, 5, 0, 0, false, false);
            int[] target = { 18, 13, 31, 14, 28, 22 };
            target[5] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x49f5a6a9c5f30364ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 24, 15, 15, 31, 12, 2, 0, 22, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 9, 3, 4, 31, 31, 3, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(4, 31, 7, 7, 1, 31, 2, 1, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 12, 31, 14, 24, 2, 0, 10, 2, 0, 0, false, false);
            int[] target = { 24, 15, 15, 12, 20, 24 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1a0a569824932885ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 28, 30, 24, 31, 11, 2, 1, 2, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 2, 3, 1, 23, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 0, 31, 14, 30, 2, 0, 19, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 13, 31, 27, 25, 2, 0, 4, 1, 0, 0, false, false);
            int[] target = { 28, 30, 24, 11, 21, 14 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf727197a69104a7cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 26, 26, 25, 31, 2, 0, 2, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 25, 24, 31, 3, 0, 24, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 17, 31, 1, 16, 2, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 12, 2, 23, 9, 2, 0, 24, 1, 0, 0, false, false);
            int[] target = { 25, 26, 26, 25, 24, 24 };
            target[5] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x126865c9fb2b291eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 14, 13, 7, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 7, 27, 3, 31, 3, 0, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 12, 17, 31, 19, 2, 0, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 14, 31, 30, 30, 30, 2, 0, 15, 1, 0, 0, false, false);
            int[] target = { 31, 14, 13, 7, 27, 3 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x26de85077fa1dbeeul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(9, 20, 27, 31, 26, 31, 2, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 27, 31, 26, 31, 3, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 11, 31, 29, 2, 2, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 30, 31, 22, 2, 1, 18, 3, 0, 0, false, false);
            int[] target = { 9, 20, 27, 26, 17, 11 };
            target[5] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xae5dc249ee1197b4ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 10, 31, 27, 24, 31, 2, 0, 18, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 31, 27, 24, 31, 3, 0, 18, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 31, 19, 28, 22, 31, 2, 1, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 18, 18, 2, 2, 0, 22, 4, 0, 0, false, false);
            int[] target = { 25, 10, 27, 24, 30, 3 };
            target[5] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xdca13ba8f1fef023ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 28, 13, 31, 27, 17, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 13, 27, 31, 31, 17, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 31, 29, 2, 25, 2, 0, 14, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 31, 27, 31, 15, 27, 2, 0, 17, 0, 0, 0, false, false);
            int[] target = { 28, 13, 27, 17, 13, 7 };
            target[5] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x32ab7d1ba5157c03ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 12, 31, 30, 21, 2, 2, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 31, 21, 31, 2, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 31, 10, 12, 31, 22, 2, 1, 3, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 13, 28, 31, 31, 12, 2, 1, 20, 0, 0, 0, false, false);
            int[] target = { 12, 30, 21, 2, 9, 17 };
            target[5] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5c10ffcb9decd7b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 20, 5, 1, 31, 29, 2, 1, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 29, 7, 31, 31, 3, 0, 11, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 14, 22, 31, 21, 8, 2, 1, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 9, 9, 2, 31, 2, 1, 0, 0, 0, 0, false, false);
            int[] target = { 20, 5, 1, 29, 7, 30 };
            target[5] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x62dc05e6dfe40c4bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 4, 19, 9, 14, 2, 0, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 9, 31, 14, 3, 0, 23, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 28, 31, 5, 31, 11, 2, 0, 14, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 11, 31, 20, 23, 18, 2, 1, 7, 1, 0, 0, false, false);
            int[] target = { 4, 19, 9, 14, 6, 27 };
            target[5] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x67de866ca3b4057aul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(27, 31, 31, 6, 18, 4, 2, 0, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(6, 31, 31, 31, 18, 4, 3, 0, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 7, 31, 31, 3, 26, 2, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 13, 31, 13, 22, 27, 2, 1, 22, 4, 0, 0, false, false);
            int[] target = { 27, 6, 18, 4, 4, 20 };
            target[5] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf3af363f0f3c21e5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 31, 1, 8, 17, 31, 2, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 31, 8, 17, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 2, 31, 0, 3, 22, 2, 0, 18, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 18, 31, 31, 0, 11, 2, 0, 16, 4, 0, 0, false, false);
            int[] target = { 28, 1, 8, 17, 21, 6 };
            target[5] = -1;
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfa680705fef93ef7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 20, 10, 29, 30, 2, 1, 2, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 10, 29, 31, 30, 3, 1, 2, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 24, 16, 31, 3, 19, 2, 0, 21, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 31, 23, 21, 1, 31, 2, 0, 12, 4, 0, 0, false, false);
            int[] target = { 20, 10, 29, 30, 25, 8 };
            target[5] = -1;
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x327499d6a1f87dfbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(5, 31, 31, 26, 19, 31, 3, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 31, 20, 31, 4, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            int[] target = { 5, 26, 19, 15, 20, 16 };
            target[5] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87e8145f67d83f11ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 29, 31, 19, 4, 3, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 31, 4, 31, 4, 1, 5, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 25, 22, 31, 6, 31, 2, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 29, 19, 4, 31, 10, 5 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(22, 31, 6, 31, 1, 31, 3, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 22, 31, 15, 31, 4, 1, 4, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 30, 31, 19, 29, 31, 2, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 3, 0, 31, 12, 2, 0, 2, 4, 0, 0, false, false);
            int[] target = { 22, 6, 1, 9, 31, 8 };
            target[5] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8d2d7749ad1313c7ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 11, 31, 31, 6, 19, 3, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 4, 8, 4, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 22, 31, 4, 14, 2, 1, 7, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            int[] target = { 11, 6, 19, 18, 23, 0 };
            target[5] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(14, 31, 19, 31, 31, 22, 3, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 5, 31, 31, 31, 4, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 5, 0, 0, false, false);
            int[] target = { 14, 19, 22, 7, 21, 20 };
            target[5] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(22, 25, 31, 31, 31, 5, 3, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(5, 31, 31, 31, 31, 15, 4, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 31, 9, 0, 5, 31, 2, 0, 6, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 25, 15, 22, 31, 31, 2, 0, 14, 3, 0, 0, false, false);
            int[] target = { 22, 25, 5, 15, 21, 25 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f40a2fb3ec1f888ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 3, 28, 31, 1, 31, 3, 1, 19, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 3, 31, 31, 31, 4, 0, 19, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 10, 31, 31, 17, 3, 2, 1, 9, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(0, 1, 17, 31, 31, 0, 2, 0, 14, 1, 0, 0, false, false);
            int[] target = { 3, 28, 1, 3, 14, 19 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x15158ba914eb52d8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(1, 15, 31, 16, 31, 31, 3, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 16, 31, 31, 4, 1, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 8, 31, 11, 10, 2, 1, 10, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 0, 0, false, false);
            int[] target = { 1, 15, 16, 21, 20, 29 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 31, 31, 2, 31, 4, 0, 23, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 2, 0, 0, false, false);
            int[] target = { 31, 31, 24, 17, 2, 0 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 31, 22, 31, 28, 31, 3, 0, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(22, 31, 28, 31, 31, 31, 4, 0, 17, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 31, 31, 2, 0, 12, 2, 1, 12, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 17, 8, 23, 31, 31, 2, 1, 11, 0, 0, 0, false, false);
            int[] target = { 20, 22, 28, 24, 30, 17 };
            target[5] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xda1db3506d655553ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 19, 31, 14, 31, 25, 3, 1, 20, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 14, 31, 31, 31, 25, 4, 1, 20, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 9, 31, 3, 31, 3, 2, 1, 11, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 6, 15, 21, 16, 2, 0, 17, 4, 0, 0, false, false);
            int[] target = { 19, 14, 25, 9, 30, 30 };
            target[5] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3a2a4a70e6a53651ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 9, 25, 31, 31, 12, 3, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 31, 12, 4, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(3, 4, 31, 31, 2, 24, 2, 1, 6, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 10, 31, 30, 13, 8, 2, 1, 13, 5, 0, 0, false, false);
            int[] target = { 9, 25, 12, 28, 6, 22 };
            target[5] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x56cc20e375d566eul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 14, 31, 31, 31, 6, 3, 0, 21, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 8, 31, 31, 31, 31, 4, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 2, 0, 0, false, false);
            int[] target = { 28, 14, 6, 12, 31, 21 };
            target[5] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 31, 31, 31, 20, 3, 0, 15, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 31, 15, 4, 1, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 4, 31, 8, 15, 2, 1, 6, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 30, 31, 31, 29, 31, 2, 0, 24, 2, 0, 0, false, false);
            int[] target = { 4, 31, 20, 26, 26, 15 };
            target[5] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9895217dee60a5f5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 13, 16, 31, 31, 19, 3, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 16, 19, 31, 31, 31, 4, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 12, 31, 31, 28, 25, 2, 1, 19, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 1, 4, 31, 18, 2, 1, 11, 4, 0, 0, false, false);
            int[] target = { 13, 16, 19, 27, 10, 31 };
            target[5] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x55ee358bb3c4d049ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(14, 31, 0, 31, 31, 31, 3, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 31, 4, 1, 10, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 0, 0, false, false);
            int[] target = { 14, 31, 0, 21, 14, 1 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 21, 1, 31, 31, 31, 3, 0, 12, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(21, 31, 1, 31, 31, 31, 4, 0, 12, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 31, 15, 18, 31, 22, 2, 1, 18, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 15, 21, 24, 10, 31, 2, 0, 7, 4, 0, 0, false, false);
            int[] target = { 25, 21, 1, 24, 18, 12 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x43ff8b09ac6578b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(28, 31, 31, 2, 31, 10, 3, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(27, 31, 31, 31, 31, 2, 4, 1, 20, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 1, 10, 7, 31, 2, 1, 12, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(5, 12, 26, 31, 31, 1, 2, 0, 0, 5, 0, 0, false, false);
            int[] target = { 28, 2, 10, 6, 3, 27 };
            target[5] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb1ade62968e5fef0ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(26, 31, 31, 31, 27, 7, 3, 0, 7, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 28, 31, 4, 1, 24, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(25, 26, 15, 31, 7, 31, 2, 0, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 14, 20, 5, 31, 2, 0, 21, 4, 0, 0, false, false);
            int[] target = { 26, 27, 7, 30, 10, 29 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb5841ab98fb62b3ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 26, 31, 31, 5, 16, 3, 1, 21, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 16, 31, 31, 9, 31, 4, 0, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 27, 31, 19, 3, 31, 2, 0, 13, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 12, 31, 31, 9, 19, 2, 1, 4, 0, 0, 0, false, false);
            int[] target = { 26, 5, 16, 9, 10, 21 };
            target[5] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc7e13f6dda9e9a35ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(30, 31, 31, 31, 28, 11, 3, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 31, 31, 31, 7, 4, 1, 8, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 31, 31, 3, 31, 7, 2, 0, 16, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 3, 31, 28, 31, 0, 2, 0, 18, 2, 0, 0, false, false);
            int[] target = { 30, 28, 11, 7, 3, 30 };
            target[5] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x61f4917777c91de5ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 31, 31, 31, 14, 19, 3, 0, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(23, 31, 31, 31, 31, 1, 4, 0, 3, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 31, 31, 23, 4, 20, 2, 0, 23, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 17, 19, 21, 31, 2, 1, 11, 1, 0, 0, false, false);
            int[] target = { 19, 14, 19, 28, 23, 1 };
            target[5] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2b10bbf5652f4974ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 31, 19, 31, 24, 31, 3, 0, 13, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 18, 31, 2, 31, 4, 1, 10, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 11, 11, 20, 11, 31, 2, 1, 6, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 7, 31, 13, 23, 2, 1, 1, 4, 0, 0, false, false);
            int[] target = { 7, 19, 24, 18, 2, 13 };
            target[5] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x51458478591bd7bdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 9, 3, 4, 31, 31, 3, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 3, 4, 31, 31, 4, 0, 11, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(4, 31, 7, 7, 1, 31, 2, 1, 24, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 12, 31, 14, 24, 2, 0, 10, 2, 0, 0, false, false);
            int[] target = { 9, 3, 4, 30, 7, 11 };
            target[5] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1a0a569824932885ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 31, 31, 10, 31, 6, 3, 1, 19, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 31, 31, 31, 31, 0, 4, 0, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 9, 4, 15, 31, 0, 2, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 1, 2, 16, 31, 31, 2, 0, 5, 4, 0, 0, false, false);
            int[] target = { 7, 10, 6, 25, 25, 19 };
            target[5] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x800c22c48d686b03ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 15, 7, 14, 31, 31, 3, 0, 0, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 0, 31, 31, 4, 1, 16, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 15, 18, 14, 31, 31, 2, 0, 17, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 24, 28, 16, 11, 31, 2, 0, 10, 1, 0, 0, false, false);
            int[] target = { 15, 7, 14, 20, 18, 27 };
            target[5] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87ff9cce51fe7040ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 25, 31, 31, 20, 13, 3, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 20, 13, 4, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(10, 31, 31, 12, 17, 29, 2, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 31, 13, 27, 25, 2, 1, 12, 2, 0, 0, false, false);
            int[] target = { 25, 20, 13, 1, 10, 18 };
            target[5] = -1;
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x964f7901de273897ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 3, 30, 21, 31, 31, 3, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 21, 31, 31, 31, 4, 0, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 24, 4, 2, 31, 31, 2, 0, 6, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 9, 8, 31, 14, 31, 2, 1, 23, 5, 0, 0, false, false);
            int[] target = { 3, 30, 21, 14, 12, 30 };
            target[5] = -1;
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x66a005ecf23cec50ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation28()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(11, 18, 31, 7, 31, 31, 3, 1, 3, 0, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 7, 31, 31, 31, 31, 4, 1, 3, 0, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 31, 2, 7, 27, 31, 2, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon4(12, 31, 0, 31, 9, 5, 2, 0, 9, 4, 0, 0, false, false);
            int[] target = { 11, 18, 7, 25, 1, 31 };
            target[5] = -1;
            var res = searcher.Calculate(28, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xbee8bf3b99da2d8dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation29()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(15, 31, 31, 29, 31, 28, 3, 0, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 31, 30, 31, 31, 4, 1, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 21, 31, 10, 22, 2, 1, 14, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 18, 13, 17, 29, 2, 1, 14, 4, 0, 0, false, false);
            int[] target = { 15, 29, 28, 30, 23, 1 };
            target[5] = -1;
            var res = searcher.Calculate(29, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa07637165382c68bul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation30()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 20, 31, 26, 30, 3, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 26, 31, 31, 30, 4, 0, 2, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 13, 31, 31, 22, 6, 2, 0, 14, 4, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 29, 31, 5, 26, 31, 2, 1, 15, 1, 0, 0, false, false);
            int[] target = { 20, 26, 30, 16, 5, 2 };
            target[5] = -1;
            var res = searcher.Calculate(30, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x10cf4c25b6bc48b8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation31()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 24, 31, 31, 31, 23, 3, 1, 3, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(24, 23, 31, 31, 31, 31, 4, 1, 3, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 4, 31, 31, 0, 21, 2, 0, 4, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 5, 31, 24, 19, 23, 2, 1, 15, 0, 0, 0, false, false);
            int[] target = { 21, 24, 23, 25, 3, 3 };
            target[5] = -1;
            var res = searcher.Calculate(31, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xca90fb7f5ef5a22dul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation32()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(22, 31, 31, 31, 17, 28, 3, 1, 3, 3, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 31, 31, 31, 25, 4, 0, 1, 3, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 2, 31, 2, 31, 10, 2, 1, 18, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 31, 14, 16, 7, 31, 2, 1, 7, 1, 0, 0, false, false);
            int[] target = { 22, 17, 28, 11, 25, 28 };
            target[5] = -1;
            var res = searcher.Calculate(32, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x703d23b2c9dfbce0ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation33()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 30, 31, 8, 18, 31, 3, 0, 12, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 12, 29, 31, 4, 0, 11, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 31, 23, 31, 16, 11, 2, 1, 4, 0, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 31, 11, 8, 4, 31, 2, 1, 6, 1, 0, 0, false, false);
            int[] target = { 30, 8, 18, 14, 23, 25 };
            target[5] = -1;
            var res = searcher.Calculate(33, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa40e07dc65799cb8ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation34()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 31, 22, 23, 31, 31, 3, 1, 9, 4, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 24, 31, 31, 31, 4, 0, 15, 4, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 31, 5, 31, 10, 19, 2, 0, 6, 5, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 30, 31, 17, 3, 31, 2, 1, 2, 0, 0, 0, false, false);
            int[] target = { 12, 22, 23, 21, 20, 9 };
            target[5] = -1;
            var res = searcher.Calculate(34, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd590d450fba73ccful, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation35()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 19, 31, 27, 20, 31, 3, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 31, 20, 31, 4, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(6, 31, 17, 9, 31, 13, 2, 1, 22, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 31, 0, 29, 28, 31, 2, 1, 21, 4, 0, 0, false, false);
            int[] target = { 19, 27, 20, 3, 2, 29 };
            target[5] = -1;
            var res = searcher.Calculate(35, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf892b015089d6ccdul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation36()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 9, 31, 0, 31, 31, 3, 1, 15, 2, 0, 0, false, false);
            searcher.RegisterPokemon2(0, 31, 31, 15, 31, 31, 4, 0, 14, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 17, 10, 31, 31, 7, 2, 1, 15, 3, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 0, 31, 17, 23, 31, 2, 1, 24, 4, 0, 0, false, false);
            int[] target = { 21, 9, 0, 15, 20, 15 };
            target[5] = -1;
            var res = searcher.Calculate(36, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc7bc46574b6a4b51ul, res[0] - 0x7817eba09827c0ef);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation37()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 13, 25, 30, 31, 31, 3, 0, 1, 5, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 30, 18, 31, 31, 4, 1, 8, 5, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 28, 17, 31, 21, 31, 2, 1, 13, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(23, 21, 28, 31, 31, 26, 2, 0, 20, 3, 0, 0, false, false);
            int[] target = { 13, 25, 30, 18, 17, 1 };
            target[5] = -1;
            var res = searcher.Calculate(37, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf101cc99d97677fcul, res[0] - 0x7817eba09827c0ef);
        }

    }
}
