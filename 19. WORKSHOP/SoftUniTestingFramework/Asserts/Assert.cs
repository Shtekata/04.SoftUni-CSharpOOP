﻿namespace SoftUniTestingFramework.Asserts
{
    using SoftUniTestingFramework.Exceptions;
    public static class Assert
    {
        public static bool AreEqual(int a, int b)
        {
            if (a != b)
            {
                throw new TestException("Values are not the same!");
            }

            return true;
        }
    }
}
