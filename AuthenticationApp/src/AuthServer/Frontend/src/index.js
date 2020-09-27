import React from 'react'
import ReactDOM from 'react-dom'
import { BrowserRouter } from 'react-router-dom'
import App from './App'
import { GlobalStyle } from './components'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')
const rootElement = document.getElementById('root')

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
    <GlobalStyle />
  </BrowserRouter>,
  rootElement
)
