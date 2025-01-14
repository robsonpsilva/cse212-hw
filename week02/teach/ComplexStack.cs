public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
/*
    The algorithm checks a mathematical formula, which has parentheses, brackets and curly brackets, 
    validating whether each of these elements is correctly closed by its corresponding element. 
    In other words, if it finds a closing parenthesis, there must have been an opening parenthesis 
    and it must be at the top of the stack. In other words, it puts the elements on the stack and 
    when it finds a closing parenthesis, it matches what is at the top of the stack. 
    For example, suppose the following mathematical formula: { a + [b + (c*d)]} the stack would 
    evolve until it looks like this: 
    1- At the top we would have "(", the parenthesis. 
    2- Below it would be "[" the square brackets. 
    3- Then the curly brackets "{". 
    For the formula to be correct, we must find the following, in this exact order: 
    1- Parentesis "(". 
    2- Square bracket "[", and, 
    3- Curly bracket "{."
*/