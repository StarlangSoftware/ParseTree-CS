For Developers
============

You can also see [Java](https://github.com/starlangsoftware/ParseTree), [Python](https://github.com/starlangsoftware/ParseTree-Py), [Cython](https://github.com/starlangsoftware/ParseTree-Cy), or [C++](https://github.com/starlangsoftware/ParseTree-CPP) repository.

## Requirements

* C# Editor
* [Git](#git)

### Git

Install the [latest version of Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git).

## Download Code

In order to work on code, create a fork from GitHub page. 
Use Git for cloning the code to your local or below line for Ubuntu:

	git clone <your-fork-git-link>

A directory called ParseTree-CS will be created. Or you can use below link for exploring the code:

	git clone https://github.com/starlangsoftware/ParseTree-CS.git

## Open project with Rider IDE

To import projects from Git with version control:

* Open Rider IDE, select Get From Version Control.

* In the Import window, click URL tab and paste github URL.

* Click open as Project.

Result: The imported project is listed in the Project Explorer view and files are loaded.


## Compile

**From IDE**

After being done with the downloading and opening project, select **Build Solution** option from **Build** menu. After compilation process, user can run ParseTree-CS.

Detailed Description
============

+ [TreeBank](#treebank)
+ [ParseTree](#parsetree)

## TreeBank

To load a TreeBank composed of saved ParseTrees from a folder:

	TreeBank(string folder)

To load trees with a specified pattern from a folder of trees: 

	TreeBank(string folder, string pattern)
	
To load trees with a specified pattern and within a specified range of numbers from a folder of trees:

	TreeBank(string folder, string pattern, int from, int to)
	
the line above is used. For example,

	a = TreeBank("/mypath");

the line below is used to load trees under the folder "mypath" which is under the current folder. If only the trees with ".train" extension under the same folder are to be loaded:

	a = TreeBank("/mypath", ".train");

If among those trees, only the ones between 1 and 500 are to be loaded:

	a = TreeBank("/mypath", ".train", 1, 500);

the line below is used. 

To iterate over the trees after the TreeBank is loaded:

	for (int i = 0; i < a.size(); i++){
		ParseTree p = a.Get(i);
	}
	
a block of code like this can be useful.

## ParseTree

To load a saved ParseTree:

	ParseTree(string fileName)
	
is used. Usually it is more useful to load a TreeBank as explained above than loading the ParseTree one by one.

To find the node number of a ParseTree:

	int NodeCount()
	
yaprak sayısını 

	int LeafCount()
	
leaf number of a ParseTree:

	int WordCount(bool excludeStopWords)
	
above methods can be used.

## Cite
If you use this resource on your research, please cite the following paper: 

```
@inproceedings{yildiz2014constructing,
  title={Constructing a {T}urkish-{E}nglish parallel treebank},
  author={Y{\i}ld{\i}z, O. T. and Solak, E. and G{\"o}rg{\"u}n, O. and Ehsani, R.},
  booktitle={Proceedings of the 52nd Annual Meeting of the Association for Computational Linguistics},
  volume={2},
  pages={112--117},
  year={2014}
}

@incollection{yildiz2015constructing,
  title={Constructing a {T}urkish constituency parse treeBank},
  author={Y{\i}ld{\i}z, O. T. and Solak, E. and {\c{C}}and{\i}r, {\c{S}}. and Ehsani, R. and G{\"o}rg{\"u}n, O.},
  booktitle={Information Sciences and Systems 2015},
  pages={339--347},
  year={2015},
  publisher={Springer}
}

@InProceedings{gorgun16,
  author    = {O. Gorgun and O. T. Yildiz and E. Solak and R. Ehsani},
  title     = {{E}nglish-{T}urkish Parallel Treebank with Morphological Annotations and its Use in Tree-based SMT},
  booktitle = {International Conference on Pattern Recognition and Methods},
  year      = {2016},
  address   = {Rome, Italy},
  pages     = {510--516}
}
