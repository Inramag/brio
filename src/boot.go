package main

import (
	"fmt"
	"os/exec"
	"strings"
)

func main() {
	cmd := exec.Command("dotnet", "--list-runtimes")
	out, err := cmd.Output()
	if err != nil || !strings.Contains(string(out), "Microsoft.WindowsDesktop.App 8.") {
		for true {
			fmt.Println("Для работы приложения требуется .NET 8.")
			fmt.Println("Вы можете скачать его с официального сайта\n    https://builds.dotnet.microsoft.com/dotnet/Runtime/8.0.25/dotnet-runtime-8.0.25-win-x64.zip")
			fmt.Println("или установить версию приложения со встроенным .NET 8 Runtime\n    ")
		}
	}
}
