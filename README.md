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
- Xunit test framework
- Serilog logging

### API Endpoint 
/ULCalculationTask/Expression

### Inputs 
- string input

### Output 
A JSON object response with containing the input expression and result

```json
ExpressionResult{
  expression 	string
  result	number($double)
}
```

# Implementation Approach

## Architecture
Followed the SOLID principles and MVC pattern where possible in the structure of the solution. But also took a pragmatic approach to not over engineer the solution.  
#### Interfaces
* IExpressionEngine - 
* IValidate - 


## Calculation

## Validation
Added validation for the following
* #### Regex rules for input expression 
  * Numbers in the range 0-9
  * Operator characters +, -, *, /
  * Not allowing two operator characters to be adjacent to each other  

- Check for decimal places
- Check that input must be greater than 2 characters





## Logging
Used Serilog nuget package to output errors and warnings to a log file in the solution log directory.  
Recording timestamp, exception or warning message with the input input expression.

## Testing
Used Xunit theory with inline data
  - Tested ExpresssionService.calculateResult method with combinations of different maths equations.
	- Tested ValidateServices.ValidExpression with combinations of malformed and correctly formatted expressions that should pass and fail validation.
	


