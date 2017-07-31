---
Order: 20
Title: Contributing
---

This is very much an active project so any and all contributions are welcome, even just finding issues!

## Reporting Issues

All issues should be tracked at [GitHub](https://github.com/cake-contrib/Cake.Transifex),
with enough information to reproduce the issue.

## Code Contributions

This repository is based around the Git Flow workflow, using feature/hotfix/bugfix branches and pull requests to manage incoming changes and fixes. Generally speaking you can follow a similar guidance as Cake itself (found [here](http://cakebuild.net/docs/contributing/guidelines)), which can be summarised as follows:

- Find a change or fix you want to implement
- Fork the repo
- Workflow for new features
  - Create a new branch named `feature/<your-feature-name>` and make your changes
  - Open a PR from your feature branch against the `develop` branch (include the GitHub issue number)
- Workflow for bug fixes in the latest stable version
  - Create a new branch named `hotfix/<your-bugfix-name>` and make your changes
  - Open a PR from your hotfix branch against the `master` branch (include the GitHub issue number)  
    *(This will be re-targeted to a different branch when accepted)*
- Workflow for bug fixes in an unpublished version of Cake.Transifex
  - Create a new branch named `bugfix/<your-bugfix-name>` and make your changes
  - Open a PR from your bugfix branch against the `develop` branch (include the GitHub issue number)
- Success! I will provide feedback if needed, or just accept the changes directly and they should appear in the next release

## License

Note that this project (and all contributions) fall under the [MIT License terms](https://github.com/cake-contrib/Cake.Transifex/blob/master/LICENSE).
