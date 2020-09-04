using System;
using System.Collections.Generic;
using System.Text;

namespace Ovning3
{
    /*
     * Det är rätt som du har gjort, för denna uppgift behöver du inte ärva från Exception för att göra den throwable. 
     * 
     */
    abstract class UserError                                        // Jag kanske har missförstått uppgiften men jag gjorde bara så att de retunerade strängar, inte "throw new Exception()".
    {
        public abstract string UEMessage();
    }

    class NumericInputError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to use a numeric input in a text-only field. This fired an error!";
        }
    }

    class TextInputError : UserError
    {
        public override string UEMessage()
        { 
            return "You tried to use a text input in a numeric-only field. This fired an error!";
        }
    }

    class RangeInputError : UserError
    {
        public override string UEMessage()
        {
            return "Your input was not within the correct range. This fired an error!";
        }
    }

    class IllegalCharError : UserError
    {
        public override string UEMessage()
        {
            {
                return "Your input contained an illegal character. This fired an error!";
            }
        }
    }

    class NegativeNumberError : UserError
    {
        public override string UEMessage()
        {
            return "Input cannot be negative number. This fired an error!";
        }

    }
}
