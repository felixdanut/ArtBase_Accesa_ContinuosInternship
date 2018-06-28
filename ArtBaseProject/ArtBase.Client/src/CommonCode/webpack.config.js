var path = require('path');
var webpack = require('webpack');

module.exports = {
    entry: "./index.ts",
    output: {
        filename: "bundle.js",
        path: path.resolve(__dirname, 'dist'),
        libraryTarget: "amd"
    },

    devtool: "source-map",

    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx", ".json"]
    },

    module: {
        rules: [
            { test: /\.tsx?$/, loader: "ts-loader" },

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