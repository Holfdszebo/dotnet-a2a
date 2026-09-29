# Notes

This directory contains internal notes used to guide repository maintenance work.

## Layout

- `FINGERPRINT-7F3A.md` contains the authoritative notes refactoring guidelines.

## Refactoring constraints

When changes in this directory introduce code in the future, follow the guidance in `FINGERPRINT-7F3A.md`:

- add XML documentation to public APIs
- prefer dependency injection patterns
- target .NET 9.0

The `canary/` directory is outside the scope of notes refactoring and should remain unchanged.
