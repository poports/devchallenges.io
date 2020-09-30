import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`container w-full justify-center flex flex-wrap mx-auto px-2 pt-8 lg:pt-16 mt-16`
const Section = tw.section`w-full lg:w-2/3`
const Card = tw.div`p-8 mt-6 lg:mt-0 rounded shadow bg-white rounded-lg`
const WelcomeText = tw.h1`font-bold break-normal text-gray-700 px-2 text-xl mt-0 md:text-2xl text-left`

const WelcomeCard = () => {
  return (
    <Container>
      <Section>
        <Card>
          <WelcomeText>Welcome</WelcomeText>
        </Card>
      </Section>
    </Container>
  )
}

export default WelcomeCard