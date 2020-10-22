import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`py-2 text-gray-500 h-full dark:bg-gray-800 bg-white border-b dark:border-gray-900 shadow-lg`
const TitleLink = tw.a`ml-6 text-lg font-bold text-gray-800 dark:text-gray-100`

const Header = () => {
  return (
    <Container>
      <TitleLink>Welcome</TitleLink>
    </Container>
  )
}

export default Header
