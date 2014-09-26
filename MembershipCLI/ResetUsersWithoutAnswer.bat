@echo off

for /F %%j in (2 3) do (
	for /F %%i in ('MembershipCLI.lnk %%j') do (
		echo USER %%i:
		MembershipCLI.lnk 1 %%i
	)
)

