## Create a GitHub Source Control Repository w/Visual Studio 2013

OK this worked for me.

1. Open the solution in Visual Studio 2013
2. Select File | Add to Source Control
3. Select the Microsoft Git Provider
4. Click 'Changes' in the Team Explorer
5. Add a comment and check it in
6. Team Explorer displays something like this

<pre><code>Commit c9f37129 created locally. Sync to share
your changes with the server.</code></pre>

- Open 'Manage NuGet Packages'
- Click Settings
- Check both boxes in 'Package Restore'
- You may need to modify the .gitignore file if publish to GitHub pushes out the NuGet files

<i>Note: You are encouraged to store your projects at c:\users\[your name]\Source\Repos\</i>

That creates a local GIT repository

1. Surf to GitHub
2. Create a new repository DO NOT SELECT Initialize this repository with a README

That creates an empty repository with no Master branch

1. Once created open the repository and copy the URL (it's on the right of the screen in the current version)
2. Go back to Visual Studio

Make sure you have the Microsoft Git Provider selected under Tools/Options/Source Control/Plug-in Selection

1. Open Team Explorer
2. Select Home | Unsynced Commits
3. Enter the GitHub URL into the yellow box
4. Click Publish
5. Select Home | Changes
6. Add a Commit comment
7. Select Commit and Push from the drop down

Your solution is now in GitHub
