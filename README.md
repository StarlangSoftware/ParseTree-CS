Constituency TreeBanks
============

When one talks about the “success” of a Natural Language Processing solution, they often refer to its ability to analyse the semantic and syntactic structure of a given sentence. Such a solution is expected to be able to understand both the linear and hierarchical order of the words in a sentence, unveil embedded structures, illustrate syntactical relationships and have a firm grasp of the argument structure. In order to meet the expectations, cutting edge Natural Language Processing systems like parsers, POS taggers or machine translation systems make use of syntactically or semantically annotated treebanks. Such treebanks offer a deep look through the surface and into the logical form of sentences.

Annotated treebanks can be categorised as constituency treebanks and dependency treebanks. Constituency treebanks offers clarity through resolving structural ambiguities, and successfully illustrates the syntagmatic relations like adjunct, complement, predicate, internal argument, external argument and such. 

The very first comprehensive annotated treebank, the Penn Treebank, was created for the English language and offers 40,000 annotated sentences. Following the Penn Treebank, numerous treebanks annotated for constituency structures were developed in different languages including French, German, Finnish, Hungarian, Chinese and Arabic.

Video Lectures
============

[<img src="https://github.com/StarlangSoftware/ParseTree/blob/master/video1.jpg" width="50%">](https://youtu.be/fY8tn8ny0m4)[<img src="https://github.com/StarlangSoftware/ParseTree/blob/master/video2.jpg" width="50%">](https://youtu.be/aNGrV3DkzAg)[<img src="https://github.com/StarlangSoftware/ParseTree/blob/master/video3.jpg" width="50%">](https://youtu.be/78KXo9tHcqQ)

For Developers
============

You can also see [Java](https://github.com/starlangsoftware/ParseTree), [Python](https://github.com/starlangsoftware/ParseTree-Py), [Cython](https://github.com/starlangsoftware/ParseTree-Cy), [Swift](https://github.com/starlangsoftware/ParseTree-Swift), [Js](https://github.com/starlangsoftware/ParseTree-Js), [C](https://github.com/starlangsoftware/ParseTree-C), or [C++](https://github.com/starlangsoftware/ParseTree-CPP) repository.

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

# Cite

	@INPROCEEDINGS{9259873,
  	author={N. {Kara} and B. {Marşan} and M. {Özçelik} and B. N. {Arıcan} and A. {Kuzgun} and N. {Cesur} and D. B. {Aslan} and O. T. {Yıldız}},
  	booktitle={2020 Innovations in Intelligent Systems and Applications Conference (ASYU)}, 
  	title={Creating A Syntactically Felicitous Constituency Treebank For Turkish}, 
  	year={2020},
  	volume={},
  	number={},
  	pages={1-6},
  	doi={10.1109/ASYU50717.2020.9259873}}
