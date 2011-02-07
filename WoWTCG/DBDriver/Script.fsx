// This file is a script that can be executed with the F# Interactive.  
// It can be used to explore and test the library project.
// Note that script files will not be part of the project build.
#r "System.Runtime.Serialization"

#load "Driver.fs"
open WoWTCGDBDriver

Accessor.Cards "e:\Coding\WoW TCG\WoWTCG\WoWTCG\Resources\cards_full.xml"
