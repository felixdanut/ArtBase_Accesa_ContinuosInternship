var path = require('path');

module.exports = {
    entry: "./src/Index.tsx",
    output: {
        filename: "bundle.js",
        path: __dirname + "/../ArtBase.WebAPI",
        // path: __dirname + "/dist",
        publicPath: "http://localhost:8080/dist"
    },

    devtool: "source-map",

    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx", ".json"]
    },

    module: {
        rules: [
            { test: /\.tsx?$/, loader: "ts-loader", options: { allowTsInNodeModules: true } },

            {
                test: /\.(png|jpg|gif)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {}
                    }
                ]
            },

            {
                test: /\.css$/,
                exclude: /node_modules/,
                loaders: ['style-loader', 'css-loader']
            },

            { enforce: "pre", test: /\.js$/, loader: "source-map-loader" }
        ]
    },
};