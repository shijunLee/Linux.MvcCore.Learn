﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hyjiacan.util.p4n.format
{

    /**
     * Define the output case of Hanyu Pinyin string
     * 
     * <p>
     * This class provides several options for outputted cases of Hanyu Pinyin
     * string, which are listed below. For example, Chinese character '民'
     * 
     * <table>
     * <tr>
     * <th>Options</th>
     * <th>Output</th>
     * </tr>
     * <tr>
     * <td>LOWERCASE</td>
     * <td align = "center">min2</td>
     * </tr>
     * <tr>
     * <td>UPPERCASE</td>
     * <td align = "center">MIN2</td>
     * </tr>
     * </table>
     * 
     * @author Li Min (xmlerlimin@gmail.com)
     * 
     */
    public class HanyuPinyinCaseType
    {

        /**
         * The option indicates that hanyu pinyin is outputted as uppercase letters
         */
        public static HanyuPinyinCaseType UPPERCASE = new HanyuPinyinCaseType("UPPERCASE");

        /**
         * The option indicates that hanyu pinyin is outputted as lowercase letters
         */
        public static HanyuPinyinCaseType LOWERCASE = new HanyuPinyinCaseType("LOWERCASE");

        /**
         * @return Returns the name.
         */
        public String getName()
        {
            return name;
        }

        /**
         * @param name
         *            The name to set.
         */
        protected void setName(String name)
        {
            this.name = name;
        }

        /**
         * Constructor
         */
        public HanyuPinyinCaseType(String name)
        {
            setName(name);
        }

        protected String name;

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is HanyuPinyinCaseType)
            {
                return this.getName() == ((HanyuPinyinCaseType)obj).getName();
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.getName().GetHashCode();
        }
    }
}
