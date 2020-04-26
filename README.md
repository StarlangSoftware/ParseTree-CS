# ParseTree-CS

For Developers
============

You can also see [Java](https://github.com/starlangsoftware/ParseTree), [Python](https://github.com/starlangsoftware/ParseTree-Py), or [C++](https://github.com/starlangsoftware/ParseTree-CPP) repository.

Detailed Description
============
+ [TreeBank](#treebank)
+ [ParseTree](#parsetree)

## TreeBank

Kaydedilmiş ParseTreelerden oluşan bir TreeBank'ı belirli bir klasörden yüklemek için

	TreeBank(string folder)

bir klasördeki ağaçlardan ismi belirli bir örüntüye sahip ağaçları yüklemek için

	TreeBank(string folder, string pattern)
	
bir klasördeki ağaçlardan ismi belirli bir örüntüye sahip ve numaraları da belirli bir aralıkta olanları yüklemek için ise

	TreeBank(string folder, string pattern, int from, int to)
	
kullanılır. Örneğin

	a = TreeBank("/mypath");

o anda bulunan klasörün altındaki "mypath" klasörünün altındaki ağaçları yüklemek için kullanılır. Aynı klasörün altındaki sadece "train" uzantılı ağaçlar yüklenecekse, 

	a = TreeBank("/mypath", ".train");

bu ağaçlardan sadece 1 ile 500 arasındaki ağaçlar yüklenecekse de

	a = TreeBank("/mypath", ".train", 1, 500);

kullanılır.

TreeBank yüklendikten sonra ağaçlar üstünde gezmek için ise,

	for (int i = 0; i < a.size(); i++){
		ParseTree p = a.Get(i);
	}
	
gibi bir kod kullanılabilir.

## ParseTree

Kaydedilmiş bir ParseTree'yi yüklemek için

	ParseTree(string fileName)
	
kullanılır. Genel olarak tek tek ParseTree yüklemek yerine yukarıda anlatıldığı gibi bir TreeBank yüklemek daha mantıklıdır.

Bir ParseTree'nin düğüm sayısını

	int NodeCount()
	
yaprak sayısını 

	int LeafCount()
	
içinde yer alan kelime sayısını da

	int WordCount(bool excludeStopWords)
	
metodları ile bulabiliriz.

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

