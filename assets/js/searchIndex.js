
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"TransifexRunnerAliases",
            content:"TransifexRunnerAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexRunnerAliases',
            title:"TransifexRunnerAliases",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"TransifexStatusSettings",
            content:"TransifexStatusSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexStatusSettings',
            title:"TransifexStatusSettings",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"TransifexRunnerSettings",
            content:"TransifexRunnerSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexRunnerSettings',
            title:"TransifexRunnerSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"TransifexRunnerRemoteSettings",
            content:"TransifexRunnerRemoteSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexRunnerRemoteSettings_1',
            title:"TransifexRunnerRemoteSettings<TSettingsType>",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"TransifexRunnerSettings",
            content:"TransifexRunnerSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexRunnerSettings_1',
            title:"TransifexRunnerSettings<TSettingsType>",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"TransifexPullSettings",
            content:"TransifexPullSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexPullSettings',
            title:"TransifexPullSettings",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"ITransifexRunnerCommands",
            content:"ITransifexRunnerCommands",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/ITransifexRunnerCommands',
            title:"ITransifexRunnerCommands",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"TransifexPushSettings",
            content:"TransifexPushSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexPushSettings',
            title:"TransifexPushSettings",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"TransifexMode",
            content:"TransifexMode",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexMode',
            title:"TransifexMode",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"TransifexInitSettings",
            content:"TransifexInitSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Transifex/api/Cake.Transifex/TransifexInitSettings',
            title:"TransifexInitSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
