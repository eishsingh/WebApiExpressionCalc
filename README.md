# Calculate Expression  

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
* IExpressionEngine - contains method declaration for the processing of the expression
* IValidate - contains method declarations for validation of the expression
#### Services
* ExpressionService - implementation of the IExpressionEngine
* ValidateService - implementation of the IEalidate interface

#### Models 
* ExpressionResult - model class of the return object from the API

## Calculation
The method CalculateResult evaluates the expression and returns the result. (At this point we have validated the input is correctly formed.)
To solve the problem we have to:
-  Iterate through each element in the expression string.
- Check whether it is a number or not
  * If it's a number then it need to be appened to the previous number if its not finished then built it up (for example if the number is more than 1 digit long i.e '250') and keep track of this.
  * If it not an number apply that math operator
    * The order of execution follows BODMAS rules Division, Multiplcation first happens before Addition or subtraction.
    * 

## Validation
Added validation for the following
* #### Regex rules for input expression 
  * Numbers in the range 0-9
  * Operator characters +, -, *, /
  * Not allowing two operator characters to be adjacent to each other  

* Check for decimal places
* Check that input must be greater than 2 characters


## Logging
Used Serilog nuget package to output errors and warnings to a log file in the solution log directory.  
Recording timestamp, exception or warning message with the input input expression.


## Testing
Used Xunit theory with inline data
* Tested ExpresssionService.calculateResult method with combinations of different maths equations.
* Tested ValidateServices.ValidExpression with combinations of malformed and correctly formatted expressions that should pass and fail validation.
	


