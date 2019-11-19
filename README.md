# BlueIrisPerformanceAdvisor
A tool which helps you improve the performance of Blue Iris 5 by analyzing your configuration.

## Proof of Concept

This tool is in the "proof-of-concept" stage.  Currently, it only knows how to find profiles where Direct-to-disc recording is not enabled, and enable it with one click per camera.  (changes don't take effect until Blue Iris is restarted)

**Planned features:**  
* Give advice on many more subjects.
  * Hardware acceleration
  * Use of a discrete GPU
  * Video scaling algorithm
  * Camera group stream resolution
  * "Limit decoding" feature
  * Disable automatic updates in Blue Iris
  * Disk space allocation
  * … much more
* Ability to restart Blue Iris after making configuration changes.
* Ability to "ignore" any advice item.
* Ability to show "ignored" advice items.
* Ability to render a configuration summary that can be copied into support forums.
* Automatic backup of Blue Iris configuration upon app start.
* Ability to cope with Blue Iris not being installed on a system it is run on.

## Compatibility

This tool is was tested against Blue Iris 5.0.6.6.  Not compatible with Blue Iris 4.

## Usage

Download the latest release from [the Releases tab](https://github.com/bp2008/BlueIrisPerformanceAdvisor/releases) and extract it anywhere on a computer with Blue Iris on it, then run `BlueIrisPerformanceAdvisor.exe`
