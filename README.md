# HexyRunner
[![Language](https://img.shields.io/badge/Lang-CSharp-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-Apache%202.0-purple.svg)](https://opensource.org/licenses/Apache-2.0)

Accepts raw hex shellcode (e.g. msfvenom hex format) as a command line argument, and runs it

## Build

For 32-bit shellcode: `csc -platform:x86 HexyRunner.cs`

For 64-bit shellcode: `csc -platform:x64 HexyRunner.cs`

## Generate Shellcode

- 32-bit test payload

```
$ msfvenom -p windows/exec CMD=notepad -f hex EXIT_FUNC=THREAD 2>/dev/null
fce8820000006089e531c0648b50308b520c8b52148b72280fb74a2631ffac3c617c022c20c1cf0d01c7e2f252578b52108b4a3c8b4c1178e34801d1518b592001d38b4918e33a498b348b01d631ffacc1cf0d01c738e075f6037df83b7d2475e4588b582401d3668b0c4b8b581c01d38b048b01d0894424245b5b61595a51ffe05f5f5a8b12eb8d5d6a018d85b20000005068318b6f87ffd5bbf0b5a25668a695bd9dffd53c067c0a80fbe07505bb4713726f6a0053ffd56e6f746570616400
```

- 64-bit test payload

```
$ msfvenom -p windows/x64/exec CMD=calc -f hex EXIT_FUNC=THREAD 2>/dev/null
fc4883e4f0e8c0000000415141505251564831d265488b5260488b5218488b5220488b7250480fb74a4a4d31c94831c0ac3c617c022c2041c1c90d4101c1e2ed524151488b52208b423c4801d08b80880000004885c074674801d0508b4818448b40204901d0e35648ffc9418b34884801d64d31c94831c0ac41c1c90d4101c138e075f14c034c24084539d175d858448b40244901d066418b0c48448b401c4901d0418b04884801d0415841585e595a41584159415a4883ec204152ffe05841595a488b12e957ffffff5d48ba0100000000000000488d8d0101000041ba318b6f87ffd5bbf0b5a25641baa695bd9dffd54883c4283c067c0a80fbe07505bb4713726f6a00594189daffd563616c6300
```

## Run

Usage `HexyRunner <Shellcode as Hex String>`

e.g. To execute the following shellcode

```
NOP
NOP
RET
```

Just run:

```
C:\>HexyRunner 9090c3
C:\>
```

## Potential Future Improvements

- When no shellcode is supplied, default to contents of `<File name of HexyRunner binary>.txt`
- Port to Linux and other operating systems

## Contribute
Contributions, feedback and ideas will be appreciated.

## License notice
Copyright (C) 2018 Paul Taylor

See LICENSE file for details.
