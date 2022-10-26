sn -k MyKey.snk
csc /t:library /keyfile:MyKey.snk Program.cs

tlbexp Program.dll /out:Program.tlb

regasm Program.DLL /regfile:Program.reg

pause