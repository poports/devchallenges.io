import { createGlobalStyle } from 'styled-components'
import tw from 'twin.macro'
import './../style.css'

export default createGlobalStyle`
  body {
    ${tw`font-sans bg-gray-100 text-gray-900 m-0 tracking-wide leading-normal`}
  }
`
