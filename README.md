# Lain - SafeTable Implementation

## Overview

Lain is a cross-language implementation of a safe table data structure, providing consistent behavior in both Lua and C# environments. The project offers a secure way to store and manage key-value pairs with built-in validation and child table capabilities.

## Features

### Core Functionality
- **Type-Safe Storage**: Only accepts strings, numbers, booleans, and tables (in Lua) or equivalent types in C#
- **Key Validation**: Ensures keys are non-empty strings without whitespace
- **Hierarchical Structure**: Supports child tables for nested data organization
- **Validation System**: Comprehensive object validation at runtime

### Cross-Language Support
- **Lua Implementation**: Lightweight metatable-based solution
- **C# Implementation**: Strongly-typed with garbage collection awareness

## Installation

### Lua
Simply include the `main.lua` file in your project:
```lua
local SafeTable = require("main")
local table = SafeTable:new()
```

### C#
Add the `Progam.cs` file to your C# project:
```csharp
using YourNamespace;

var table = new SafeTable();
```

## API Reference

### Common Methods (Both Implementations)

#### `set(key, value)`
- Stores a value with the given key after validation
- Returns: boolean (C#) or nil (Lua) on failure

#### `get(key)`
- Retrieves the value associated with the key
- Returns: value or null/nil if not found

#### `child()`/`CreateChild()`
- Creates a new child table
- Returns: new child table or null/nil on failure

#### `validate()`
- Verifies the table's integrity
- Returns: boolean indicating validity

### C# Exclusive Methods
- `Clear()`: Removes all data and children, triggers garbage collection

## Usage Example

### Lua
```lua
local table = SafeTable:new()
table:set("name", "Lain")
local child = table:child()
child:set("version", 1.0)
```

### C#
```csharp
var table = new SafeTable();
table.Set("name", "Lain");
var child = table.CreateChild();
child.Set("version", 1.0);
```

## Performance Considerations

The C# implementation includes:
- Sustained low-latency garbage collection mode during operations
- Explicit garbage collection calls when clearing tables
- Type checking optimizations

## License

This project is open-source and available under the MIT License.

## Notes

The implementation is named "Lain" after the anime character from "Serial Experiments Lain", reflecting the project's focus on secure data layering and validation across different realms (programming languages in this case).
