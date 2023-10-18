# Evaluate Expression  

### Requirements
This is a C# Web API application that takes a string expression and calculates the output

- '+ - / *' operators only 
- Normal mathematical rules of operator precedence 
- No support of brackets needed

For example:  
an input string of "4+5*2" should output 14  
an input string of "4+5/2" should output 6.5  
an input string of "4+5/2-1" should output 5.5  

### Tech Stack
- ASP.Net Core Web API
- C# .NET 6
- Xunit unit test
- Serlog logging

### Inputs 
- string input

### Output 
A JSON response with containing the input and result

```json
ExpressionResult{
  expression 	string
  result	number($double)
}
```
