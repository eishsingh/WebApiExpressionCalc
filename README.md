# Evaluate Expression
This is a C# Web API application that takes a string expression and calculates the output

### Tech Stack
- ASP.Net Core Web API
- C# .NET 6
- Xunit unit test
- Serlog logging

### Requirements
- '+ - / *' operators only 
- Normal mathematical rules of operator precedence 
- No support of brackets needed
  

### Inputs 
- string input

### Output 
A JSON response with containing the input and result
ExpressionResult{
  expression 	string
  result	number($double)
}
