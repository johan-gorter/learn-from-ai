# Save the current directory
$originalDir = Get-Location

try {
  Set-Location LearnFromAI.Web
  dotnet watch run --non-interactive
}
finally {
  # Return to the original directory
  Set-Location $originalDir
}
