# Markdown
## Enumerations
It is possible to enumerate some lines. Numbering is done within markdown automatically, therefore, it is sufficient to prefix each numbering line with some number:

```md
1. First item
1. Griasdi
1. Pfiati
```

Result:
1. First item
1. Griasdi
1. Pfiati

Furthermore one could define the start number via the number given for the first enumeration line. Further numbers are again generated automatically no matter which number given in markdown:

```md
2. First item
1. Griasdi
1. Pfiati
```

Result:

2. First item
1. Griasdi
1. Pfiati


## Tables
```md
|   A   |   B   |   C   |   D   |
|-------|-------|-------|-------|
|   A1    |   A2    |   A3    |   A4    |
|   B1    |   B2    |   Ein langes B3    |       |
|       |       |       |       |
|       |       |       |       |
|       |       |       |       |
|       |       |       |       |
```
Result
|   A   |   B   |   C   |   D   |
|-------|-------|-------|-------|
|   A1    |   A2    |   A3    |   A4    |
|   B1    |   B2    |   Ein langes B3    |       |
|       |       |       |       |
|       |       |       |       |
|       |       |       |       |
|       |       |       |       |

Since typing a table by hand is really tedious it is recommended to use a markdown table generator, e.g., https://www.tablesgenerator.com/markdown_tables.

## Code
### Inline Code Segments
It is possible to write code segments inline by starting with one backtick (\`). Example
```md
The statement `Console.WriteLine("Some Text")` writes "Some Text" into the console.
```
Result: The statement `Console.WriteLine("Some Text")` writes "Some Text" into the console.

### Code Blocks
Code blocks show code with some extra white space above and below. Furthermore it is possible to state the programming language to which the code to be shown belongs to. This does then a proper syntax highlighting:
````md
```cs
Console.WriteLine("Pfui");
```
````

Result:
```cs
Console.WriteLine("Pfui");
```

## Links
Details about this code can be found on the [following website](https://www.google.at). But it is also possible to [link to an internal page](docs/details.md).
