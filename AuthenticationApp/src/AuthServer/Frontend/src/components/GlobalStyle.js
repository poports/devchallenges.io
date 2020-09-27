import { createGlobalStyle } from 'styled-components'
import tw from 'twin.macro'
import './../style.css'

export default createGlobalStyle`
  body {
    ${tw`font-sans bg-gradient-to-br from-gray-100 to-gray-400 m-0`}
  }
`
