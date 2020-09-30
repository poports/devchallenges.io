import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`container w-full justify-center flex flex-wrap mx-auto px-2 pt-8 lg:pt-16 mt-16`
const Section = tw.section`w-full lg:w-2/3`
const SectionHeadline = tw.h1`font-bold break-normal text-gray-700 px-2 text-xl mt-12 mb-0 lg:mt-0 md:text-2xl text-center`
const SectionDescription = tw.p`text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight text-center`

const Card = tw.div`p-8 mt-6 lg:mt-0 rounded shadow bg-white rounded-lg`
const CardHeadline = tw.h2`font-bold break-normal text-gray-700 px-2 text-xl mb-0 md:text-2xl text-left`
const CardDescription = tw.p`text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight`
const CardItem = tw.div`lg:flex mb-6 lg:items-center lg:mr-12`
const CardItemLeft = tw.div`w-1/4`
const CardItemRight = tw.div`w-3/4`
const CardItemLabel = tw.span`text-gray-600 font-semibold md:text-left text-sm mb-3 md:mb-0 pr-4 uppercase`
const CardItemValue = tw.span`w-full px-4 h-10 rounded-lg border border-gray-500 focus:border-blue-400`
const Line = tw.div`my-10 border-b-2 border-red-500 `

const ProfileCard = () => {
  return (
    <Container>
      <Section>
        <SectionHeadline>Personal info</SectionHeadline>
        <SectionDescription>
          Basic info, like your name and photo
        </SectionDescription>
        <Card>
          <CardHeadline>Profile</CardHeadline>
          <CardDescription>
            Changes will be reflected to every services
          </CardDescription>
          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Photo</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>[Photo]</CardItemValue>
            </CardItemRight>
          </CardItem>
          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Name</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>Roberto</CardItemValue>
            </CardItemRight>
          </CardItem>
          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Bio</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>Developer</CardItemValue>
            </CardItemRight>
          </CardItem>
          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Phone</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>1234567890</CardItemValue>
            </CardItemRight>
          </CardItem>
          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Email</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>poports@gmail.com</CardItemValue>
            </CardItemRight>
          </CardItem>
        </Card>
      </Section>
    </Container>
  )
}

export default ProfileCard
